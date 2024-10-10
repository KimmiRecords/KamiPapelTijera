using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct LightState
{
    public Vector3 lightPosition;
    public Vector3 lightRotation;
    public Color lightColor;
    public float lightIntensity;
}

public class LightCycler : MonoBehaviour
{
    private new Light light; //la luz que se va a mover en cuestion
    [SerializeField] LightState[] _lightStates; //los distintos tipos de luz que va a haber en cada pag
    LightState _currentLightState;

    [SerializeField] float _transitionDuration = 2f;

    private void Start()
    {
        light = GetComponent<Light>();
        _currentLightState = _lightStates[0];
        OnChangeLightState(PageScrollerManager.Instance.activePageIndex);
        EventManager.Subscribe(Evento.OnPageTurnStart, OnChangeLightState); //param0 es activeindex
    }

    public void OnChangeLightState(params object[] parameters)
    {
        _currentLightState = _lightStates[(int)parameters[0]];

        ChangeLightPosition(_currentLightState.lightPosition);
        ChangeLightRotation(_currentLightState.lightRotation);
        ChangeLightColor(_currentLightState.lightColor);
        ChangeLightIntensity(_currentLightState.lightIntensity);
    }

    public void ChangeLightPosition(Vector3 newPosition)
    {
        StartCoroutine(LerpVector3Coroutine(light.transform.position, newPosition, _transitionDuration));
        light.transform.position = newPosition;
    }

    public void ChangeLightRotation(Vector3 newRotation)
    {
        StartCoroutine(LerpVector3Coroutine(light.transform.eulerAngles, newRotation, _transitionDuration));
        light.transform.eulerAngles = newRotation;
    }

    public void ChangeLightColor(Color newColor)
    {
        StartCoroutine(LerpColorCoroutine(light.color, newColor, _transitionDuration));
        light.color = newColor;
    }

    public void ChangeLightIntensity(float newIntensity)
    {
        StartCoroutine(LerpFloatCoroutine(light.intensity, newIntensity, _transitionDuration));
        light.intensity = newIntensity;
    }

    public IEnumerator LerpVector3Coroutine(Vector3 currentVector, Vector3 targetVector, float transitionDuration)
    {
        Vector3 startPosition = currentVector;
        float elapsedTime = 0f;
        float t;

        while (elapsedTime < transitionDuration)
        {
            t = Mathf.SmoothStep(0, 1, elapsedTime / transitionDuration);
            transform.position = Vector3.Lerp(startPosition, targetVector, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetVector;
    }

    public IEnumerator LerpColorCoroutine(Color currentColor, Color targetColor, float transitionDuration)
    {
        Color startColor = currentColor;
        float elapsedTime = 0f;
        float t;

        while (elapsedTime < transitionDuration)
        {
            t = Mathf.SmoothStep(0, 1, elapsedTime / transitionDuration);
            light.color = Color.Lerp(startColor, targetColor, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        light.color = targetColor;
    }

    public IEnumerator LerpFloatCoroutine(float currentFloat, float targetFloat, float transitionDuration)
    {
        float startFloat = currentFloat;
        float elapsedTime = 0f;
        float t;

        while (elapsedTime < transitionDuration)
        {
            t = Mathf.SmoothStep(0, 1, elapsedTime / transitionDuration);
            light.intensity = Mathf.Lerp(startFloat, targetFloat, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        light.intensity = targetFloat;
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPageTurnStart, OnChangeLightState);
        }
    }
}


