using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : Singleton<PostProcessManager>
{
    [SerializeField] Volume bloomVolume;

    [SerializeField] float bloomLerpTime = 3;
    [SerializeField] float maxBloom = 30f;
    [SerializeField] float baseBloom = 3f;

    ColorAdjustments colorAdjustment;
    Bloom bloom;

    private void Start()
    {
        ColorAdjustments colorAdj;
        Bloom bloomAdj;

        if (bloomVolume.profile.TryGet<ColorAdjustments>(out colorAdj))
        {
            colorAdjustment = colorAdj;
        }

        if (bloomVolume.profile.TryGet<Bloom>(out bloomAdj))
        {
            bloom = bloomAdj;
        }
    }

    public void SetBrightnessValue(float value)
    {
        //colorGrading.postExposure.value = value;
        colorAdjustment.postExposure.value = value; 
    }

    public void SetContrastValue(float value)
    {
        //colorGrading.contrast.value = value;
        colorAdjustment.contrast.value = value;
    }

    public IEnumerator LerpBloomIntensity()
    {
        float t = 0;
        while (t < bloomLerpTime)
        {
            bloom.intensity.value = Mathf.Lerp(baseBloom, maxBloom, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0;
        while (t < bloomLerpTime)
        {
            bloom.intensity.value = Mathf.Lerp(maxBloom, baseBloom, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
