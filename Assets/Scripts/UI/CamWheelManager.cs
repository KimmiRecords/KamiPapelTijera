using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamWheelManager : Singleton<CamWheelManager>, IFlap
{
    [SerializeField] GameObject camWheelParent;
    [SerializeField] float _posXOpen;
    [SerializeField] float _posYOpen;
    [SerializeField] float _transitionDuration;

    bool _isOpen;
    float _posXClosed, _posYClosed;

    public void Start()
    {
        _posXClosed = camWheelParent.transform.localPosition.x;
        _posYClosed = camWheelParent.transform.localPosition.y;

        _posXOpen += 960;
        _posYOpen += 540;

    }
    public void OpenFlap()
    {
        Debug.Log("open flap");
        AudioManager.instance.PlayByName("PageTurn02", 2.6f, 0.01f);
        StopAllCoroutines();
        StartCoroutine(MoveFlap(_posXOpen, _posYOpen, _transitionDuration));
    }
    public void CloseFlap()
    {
        Debug.Log("close flap");

        AudioManager.instance.PlayByName("PageTurn01", 2.6f, 0.01f);
        StopAllCoroutines();
        StartCoroutine(MoveFlap(_posXClosed, _posYClosed, _transitionDuration));
    }
    public IEnumerator MoveFlap(float targetX, float targetY, float transitionDuration)
    {
        Debug.Log("move flap");

        Vector3 startPosition = camWheelParent.transform.localPosition;
        Debug.Log(startPosition);
        Vector3 targetPosition = new Vector3(targetX, targetY, camWheelParent.transform.localPosition.z);
        Debug.Log(targetPosition);
        float elapsedTime = 0f;
        float t;

        while (elapsedTime < transitionDuration)
        {
            t = Mathf.SmoothStep(0, 1, elapsedTime / transitionDuration);
            camWheelParent.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        camWheelParent.transform.localPosition = targetPosition;
        _isOpen = (targetY == _posYOpen);
    }

    public void ToggleFlap()
    {
        Debug.Log("toggle flap");

        if (_isOpen)
        {
            CloseFlap();
        }
        else
        {
            OpenFlap();
        }
    }

    public void ChangeCamera(int index)
    {
        Debug.Log("change camera" + index);
        AudioManager.instance.PlayByName("PickupSFX", 0.8f - (index/100f));
        CameraManager.Instance.SetCamera(index);
    }
}
