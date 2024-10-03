using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashCamaraController : MonoBehaviour
{
    [SerializeField] float delayUntilStart = 5;
    [SerializeField] Cinemachine.CinemachineVirtualCamera[] _virtualCameras;
    [SerializeField] int startingCamera = 0;
    [SerializeField] int finalCamera = 1;

    int currentCamera = 0;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayUntilStart);
        GoBackAndForthBetweenCameras();
    }

    public void SetCamera(int cam)
    {
        TurnOffAllVirtualCameras();
        currentCamera = cam;
        _virtualCameras[currentCamera].gameObject.SetActive(true);
    }

    public void TurnOffAllVirtualCameras()
    {
        foreach (Cinemachine.CinemachineVirtualCamera cam in _virtualCameras)
        {
            cam.gameObject.SetActive(false);
        }
    }

    public void GoBackAndForthBetweenCameras()
    {
        if (currentCamera == startingCamera)
        {
            SetCamera(finalCamera);
        }
        else
        {
            SetCamera(startingCamera);
        }
    }
}
