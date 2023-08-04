using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlapManager : Singleton<FlapManager>
{
    [SerializeField] float posYOpen = 350;
    [SerializeField] float flapTransitionDuration = 0.5f; // Tiempo de transición en segundos
    float posYClosed = 0;
    bool isOpen = false;

    [SerializeField] GameObject seguroOverlay;
    [SerializeField] Slider sliderBrillo, sliderContraste, sliderVolumen;
    float valueBeforeMute = 1;

    private void Start()
    {
        posYClosed = transform.position.y;
        EventManager.Subscribe(Evento.OnPlayerPressedEsc, ToggleFlap);
        EventManager.Subscribe(Evento.OnPlayerPressedM, ToggleMute);
    }

    public void OpenFlap()
    {
        Debug.Log("FlapManager: open flap");
        AudioManager.instance.PlayByName("PageTurn02", 1.6f, 0.01f);
        StopAllCoroutines();
        StartCoroutine(MoveFlap(posYOpen));
    }   

    public void CloseFlap()
    {
        Debug.Log("FlapManager: close flap");
        AudioManager.instance.PlayByName("PageTurn01", 1.6f, 0.01f);
        StopAllCoroutines();
        StartCoroutine(MoveFlap(posYClosed));
    }

    public void ToggleFlap(params object[] parameters)
    {
        if (isOpen)
        {
            CloseFlap();
        }
        else
        {
            OpenFlap();
        }
    }

    private IEnumerator MoveFlap(float targetY)
    {
        Time.timeScale = 1;
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;
        float t;

        while (elapsedTime < flapTransitionDuration)
        {
            t = Mathf.SmoothStep(0, 1, elapsedTime / flapTransitionDuration);
            transform.position = Vector3.Lerp(startPosition, new Vector3(transform.position.x, targetY, transform.position.z), t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
        isOpen = (targetY == posYOpen);
        if (isOpen)
        {
            Time.timeScale = 0;
        }
    }

    public void BTN_Salir()
    {
        seguroOverlay.SetActive(true);
        Debug.Log("prendo el overlay");
        AudioManager.instance.PlayByName("PickupSFX", 2.5f);
    }

    public void BTN_Si()
    {
        Debug.Log("chau :(");
        AudioManager.instance.PlayByName("PickupSFX", 2.5f);

        Application.Quit();
    }

    public void BTN_No()
    {
        seguroOverlay.SetActive(false);
        AudioManager.instance.PlayByName("PickupReversedSFX", 2.5f);

        Debug.Log("apago el overlay");
    }

    public void SLIDER_Volumen()
    {
        AudioManager.instance.SetGlobalVolume(sliderVolumen.value);
    }

    public void SLIDER_Brillo()
    {
        PostProcessManager.Instance.SetBrightnessValue(sliderBrillo.value);
    }

    public void SLIDER_Contraste()
    {
        PostProcessManager.Instance.SetContrastValue(sliderContraste.value);
    }

    public void ToggleMute(params object[] parameters)
    {
        Debug.Log("toggle mute");

        if (sliderVolumen.value == 0)
        {
            sliderVolumen.value = valueBeforeMute;
        }
        else
        {
            valueBeforeMute = sliderVolumen.value;
            sliderVolumen.value = 0;
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedEsc, ToggleFlap);
            EventManager.Unsubscribe(Evento.OnPlayerPressedM, ToggleMute);
        }
    }
}
