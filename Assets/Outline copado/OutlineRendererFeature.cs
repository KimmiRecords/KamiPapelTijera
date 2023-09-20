using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Engine.Rendering
{
    public enum JFAOutlinePass
    {
        SpriteRender = 0,
        AlphaMask = 1,
        Init = 2,
        Flood = 3,
        Outline = 4
    }
    
    public class OutlineRendererFeature : ScriptableRendererFeature
    {
        private BufferPopulatePass _populatePass;
        [SerializeField] private Material outlineMaterial;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private float outlinePixelWidth = 2f;

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            renderer.EnqueuePass(_populatePass);
        }

        public override void Create()
        {
            _populatePass = new BufferPopulatePass(outlineMaterial, targetLayers, outlinePixelWidth);
            _populatePass.renderPassEvent = RenderPassEvent.BeforeRenderingTransparents;
        }
    }
    
    public class BufferPopulatePass : ScriptableRenderPass
    {
        private static readonly int MaskBufferID = Shader.PropertyToID("_OutlineMaskBuffer");
        private static readonly int JumpFloodBufferPingID = Shader.PropertyToID("_JFBPing");
        private static readonly int JumpFloodBufferPongID = Shader.PropertyToID("_JFBPong");
        private static readonly int StepWidthID = Shader.PropertyToID("_StepWidth");
        private static readonly int AxisWidthID = Shader.PropertyToID("_AxisWidth");

        private readonly Material _outlineMaterial;
        private readonly float _outlinePixelWidth;
        private FilteringSettings _filteringSettings;
        private readonly List<ShaderTagId> _tags;
        private readonly LayerMask _layerMask;
        private readonly ProfilingSampler _profilingSampler;

        public BufferPopulatePass(Material outlineMaterial, LayerMask targetLayers, float outlinePixelWidth)
        {
            _outlineMaterial = outlineMaterial;
            _filteringSettings = new FilteringSettings(RenderQueueRange.transparent, targetLayers);
            _layerMask = targetLayers;
            _tags = new List<ShaderTagId>();
            _tags.Add(new ShaderTagId("PlayerCharacter"));
            _outlinePixelWidth = outlinePixelWidth;
            _profilingSampler = new ProfilingSampler("Buffer Populate Pass");
        }

        public override void Configure(CommandBuffer cb, RenderTextureDescriptor cameraTextureDescriptor)
        {
            var rtd = new RenderTextureDescriptor(
                cameraTextureDescriptor.width, 
                cameraTextureDescriptor.height,
                GraphicsFormat.R8_UNorm,
                0,
                0
            );
            cb.GetTemporaryRT(MaskBufferID, rtd, FilterMode.Point);
            var rtd2 = new RenderTextureDescriptor(
                cameraTextureDescriptor.width, 
                cameraTextureDescriptor.height,
                GraphicsFormat.R16G16_SNorm,
                0,
                0
            );
            cb.GetTemporaryRT(JumpFloodBufferPingID, rtd2, FilterMode.Point);
            cb.GetTemporaryRT(JumpFloodBufferPongID, rtd2, FilterMode.Point);
            ConfigureTarget(MaskBufferID);
            ConfigureClear(ClearFlag.Color, Color.clear);
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            var drawingSettings = CreateDrawingSettings(_tags, ref renderingData, SortingCriteria.CommonTransparent);
            drawingSettings.enableDynamicBatching = true;
            drawingSettings.SetShaderPassName((int) JFAOutlinePass.AlphaMask, new ShaderTagId("BUFFERFILL"));
            
            context.DrawRenderers(renderingData.cullResults, ref drawingSettings, ref _filteringSettings);
            
            // Alan Wolfe's separable axis JFA - https://www.shadertoy.com/view/Mdy3D3
            var numMips = Mathf.CeilToInt(Mathf.Log(_outlinePixelWidth + 1.0f, 2f));
            
            var cmd = CommandBufferPool.Get();
            using (new ProfilingScope(cmd, _profilingSampler))
            {
                cmd.Blit(MaskBufferID, JumpFloodBufferPingID, _outlineMaterial, 2);

                for (int i = numMips - 1; i >= 0; i--)
                {
                    // calculate appropriate jump width for each iteration
                    // + 0.5 is just me being cautious to avoid any floating point math rounding errors
                    float stepWidth = Mathf.Pow(2, i) + 0.5f;

                    // the two separable passes, one axis at a time
                    cmd.SetGlobalVector(AxisWidthID, new Vector2(stepWidth, 0f));
                    cmd.Blit(JumpFloodBufferPingID, JumpFloodBufferPongID, _outlineMaterial, (int)JFAOutlinePass.Flood);
                    cmd.SetGlobalVector(AxisWidthID, new Vector2(0f, stepWidth));
                    cmd.Blit(JumpFloodBufferPongID, JumpFloodBufferPingID, _outlineMaterial, (int)JFAOutlinePass.Flood);
                }

                cmd.SetGlobalTexture(MaskBufferID, MaskBufferID);
                cmd.Blit(JumpFloodBufferPingID, renderingData.cameraData.renderer.cameraColorTarget, _outlineMaterial,
                    (int)JFAOutlinePass.Outline);
            }

            context.ExecuteCommandBuffer(cmd);
            CommandBufferPool.Release(cmd);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            cmd.ReleaseTemporaryRT(MaskBufferID);
            cmd.ReleaseTemporaryRT(JumpFloodBufferPingID);
            cmd.ReleaseTemporaryRT(JumpFloodBufferPongID);
        }
    }
}