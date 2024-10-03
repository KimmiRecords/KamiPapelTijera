using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashFadeIn : MonoBehaviour
{
    //se llama asi porque ImageFadeIn ya existe
    //pero esta es la posta image fade in

    [SerializeField] Image image;
    [SerializeField] float fadeSpeed;
    Color originalColor;

    private void Start()
    {
        FadeIn();
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public IEnumerator FadeInCoroutine()
    {
        originalColor = image.color;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * fadeSpeed;
            image.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(0, 1, t));
            yield return null;
        }
    }
}
