using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessManager : Singleton<PostProcessManager>
{
    [SerializeField] PostProcessVolume postProcessVolume;
    PostProcessProfile profile;
    ColorGrading colorGrading;

    private void Start()
    {
        profile = postProcessVolume.profile;
        colorGrading = profile.GetSetting<ColorGrading>();
    }

    public void SetBrightnessValue(float value)
    {
        colorGrading.postExposure.value = value;
    }

    public void SetContrastValue(float value)
    {
        colorGrading.contrast.value = value;
    }



}
