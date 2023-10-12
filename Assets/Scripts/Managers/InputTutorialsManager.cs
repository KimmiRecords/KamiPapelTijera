using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorialsManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] tutorials;
    [SerializeField] float lerpDuration = 2f;

    bool alreadyTriggeredWASD, alreadyTriggeredSPACE = false;

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerMove, HideWASDTutorial);
        EventManager.Subscribe(Evento.OnPlayerPressedSpace, HideSPACETutorial);
    }

    public void HideWASDTutorial(params object[] parameters)
    {
        if (!alreadyTriggeredWASD)
        { 
            StartCoroutine(HideTutorialCoroutine(tutorials[0], lerpDuration));
            alreadyTriggeredWASD = true;
        }

    }

    public void HideSPACETutorial(params object[] parameters)
    {
        if (!alreadyTriggeredSPACE)
        {
            StartCoroutine(HideTutorialCoroutine(tutorials[1], lerpDuration));
            alreadyTriggeredSPACE = true;
        }
    }

    IEnumerator HideTutorialCoroutine(SpriteRenderer tutorial, float duration)
    {
        float elapsedTime = 0;
        float startAlpha = tutorial.color.a;

        while (elapsedTime < duration)
        {
            //Debug.Log("lerpeo");
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0, elapsedTime / duration);
            tutorial.material.SetColor("_BaseColor", new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b, newAlpha));
            yield return null;
        }

        tutorial.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerMove, HideWASDTutorial);
            EventManager.Unsubscribe(Evento.OnPlayerPressedSpace, HideSPACETutorial);

        }
    }
}
