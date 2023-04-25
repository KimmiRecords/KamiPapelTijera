using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFadeIn : MonoBehaviour
{
    [SerializeField]
    float fadeSpeed; // velocidad a la que se hace el fade in
    [SerializeField]
    float holdTime;
    
    Image image; // la imagen que quieres hacer fade in (en este caso, yo mismo)
    bool isHolding;

    private void Start()
    {
        image = GetComponent<Image>();

        //empieza transparente
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        isHolding = true;
        StartCoroutine(HoldCoroutine());
    }

    private void Update()
    {
        if (!isHolding)
        {
            // si la imagen no es totalmente visible, aumenta su opacity
            if (image.color.a > 0)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (fadeSpeed * Time.deltaTime));
            }
        }
    }

    public IEnumerator HoldCoroutine()
    {
        yield return new WaitForSeconds(holdTime);
        isHolding = false;
    }
}
