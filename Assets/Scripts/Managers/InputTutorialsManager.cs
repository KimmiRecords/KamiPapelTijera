using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTutorialsManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] tutorials;
    [SerializeField] float lerpDuration = 2f;

    void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerMove, HideWASDTutorial);
        EventManager.Subscribe(Evento.OnPlayerPressedSpace, HideSPACETutorial);
    }

    public void HideWASDTutorial(params object[] parameters)
    {
        StartCoroutine(HideTutorialCoroutine(tutorials[0], lerpDuration));
    }

    public void HideSPACETutorial(params object[] parameters)
    {
        StartCoroutine(HideTutorialCoroutine(tutorials[1], lerpDuration));
    }

    IEnumerator HideTutorialCoroutine(SpriteRenderer tutorial, float duration)
    {
        float elapsedTime = 0;
        float startAlpha = tutorial.color.a;

        while (elapsedTime < duration)
        {
            Debug.Log("lerpeo");
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0, elapsedTime / duration);
            tutorial.material.SetColor("_BaseColor", new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b, newAlpha));
            yield return null;
        }

        tutorial.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Evento.OnPlayerMove, HideWASDTutorial);
        EventManager.Unsubscribe(Evento.OnPlayerPressedSpace, HideSPACETutorial);
    }
}
