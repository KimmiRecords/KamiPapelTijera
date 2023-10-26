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
    private new Light light;
    [SerializeField] LightState[] _lightStates;
    LightState _currentLightState;

    //a series of methods that change the light's position, rotation, color and intensity
    //these methods should be called by the event manager, which should be called by the page scroller manager
    //these methods should store the original values of the light, so that they can be restored when the player goes back to the original page
    private void Start()
    {
        light = GetComponent<Light>();
        _currentLightState = _lightStates[0];
        OnChangeLightState(PageScrollerManager.Instance.activePageIndex);
        EventManager.Subscribe(Evento.OnPageTurned, OnChangeLightState); //param0 es activeindex
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
        light.transform.position = newPosition;
    }

    public void ChangeLightRotation(Vector3 newRotation)
    {
        light.transform.eulerAngles = newRotation;
    }

    public void ChangeLightColor(Color newColor)
    {
        light.color = newColor;
    }

    public void ChangeLightIntensity(float newIntensity)
    {
        light.intensity = newIntensity;
    }
}


