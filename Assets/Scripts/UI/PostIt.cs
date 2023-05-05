using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostIt : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI tmPro;

    [SerializeField]
    float transitionTime = 0.5f;

    //[SerializeField]
    //PostIt color;

    Vector3 outsidePos;

    void Start()
    {
        outsidePos = transform.position;
    }

    public void SlideIn()
    {
        StartCoroutine(SlideInCoroutine());
    }

    public void SlideOut()
    {
        StartCoroutine(SlideOutCoroutine());
    }

    public IEnumerator SlideInCoroutine()
    {
        float timer = 0;

        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(outsidePos, outsidePos + Vector3.left, timer);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator SlideOutCoroutine()
    {
        float timer = 0;

        while (timer < transitionTime)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(outsidePos + Vector3.left, outsidePos, timer);
            yield return new WaitForEndOfFrame();
        }
    }
}
