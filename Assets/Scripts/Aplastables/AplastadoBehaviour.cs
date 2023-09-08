using System.Collections;
using UnityEngine;

public class AplastadoBehaviour : MonoBehaviour, IAplastable
{
    public float lerpTime;

    public virtual void Aplastar()
    {
        //Debug.Log("Aplastado: Aplastar");
        StartCoroutine(LerpScaleY(transform, lerpTime));
    }

    protected IEnumerator LerpScaleY(Transform targetTransform, float time)
    {
        Vector3 startScale = targetTransform.localScale;
        Vector3 endScale = new(targetTransform.localScale.x, 0.01f, targetTransform.localScale.z);

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            targetTransform.localScale = Vector3.Lerp(startScale, endScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetTransform.localScale = endScale;
        //Debug.Log("Aplastado: termine la corrutina");
    }


}
