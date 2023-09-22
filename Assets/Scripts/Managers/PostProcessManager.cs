using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static Unity.Burst.Intrinsics.X86.Avx;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : Singleton<PostProcessManager>
{
    [SerializeField] Volume bloomVolume;
    [SerializeField] Volume colorGradingVolume;

    [SerializeField] float bloomLerpTime = 3;
    [SerializeField] float maxWeight = 0.05f;
    [SerializeField] float minWeight = 1;

    ColorAdjustments colorAdjustment;

    private void Start()
    {
        ColorAdjustments colorAdj;

        if (colorGradingVolume.profile.TryGet<ColorAdjustments>(out colorAdj))
        {
            colorAdjustment = colorAdj;
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
            bloomVolume.weight = Mathf.Lerp(minWeight, maxWeight, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0;
        while (t < bloomLerpTime)
        {
            bloomVolume.weight = Mathf.Lerp(maxWeight, minWeight, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
