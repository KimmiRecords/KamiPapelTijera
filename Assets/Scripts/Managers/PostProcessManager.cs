using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : Singleton<PostProcessManager>
{
    [SerializeField] PostProcessVolume postProcessVolume;
    PostProcessProfile profile;
    ColorGrading colorGrading;
    Bloom bloom;

    [SerializeField] float bloomLerpTime = 3;
    [SerializeField] float maximumBloomIntensity = 40;

    private void Start()
    {
        profile = postProcessVolume.profile;
        colorGrading = profile.GetSetting<ColorGrading>();
        bloom = profile.GetSetting<Bloom>();
    }

    public void SetBrightnessValue(float value)
    {
        colorGrading.postExposure.value = value;
    }

    public void SetContrastValue(float value)
    {
        colorGrading.contrast.value = value;
    }

    public IEnumerator LerpBloomIntensity()
    {
        float t = 0;
        while (t < bloomLerpTime)
        {
            bloom.intensity.value = Mathf.Lerp(3, 60, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        t = 0;
        while (t < bloomLerpTime)
        {
            bloom.intensity.value = Mathf.Lerp(60, 3, t);
            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }



}
