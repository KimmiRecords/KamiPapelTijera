using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol2DPickup : SpritePickup
{
    [SerializeField] float targetRotationX;
    [SerializeField] float lerpTime;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        //si el other tiene getcomponent de iaplastable, dispararle el metodo .aplastar
        if (other.GetComponent<IAplastable>() != null)
        {
            Debug.Log("aplaste algo");
            other.GetComponent<IAplastable>().Aplastar();
        }
    }

    public override void Jump()
    {
        if (haceSaltito)
        {
            if (isReadyToJump)
            {
                Debug.Log("arbol salta");
                miCortable.pickupRB.AddForce(Vector3.back * miCortable.jumpForce);
                LerpRotationX(targetRotationX, lerpTime);
                isReadyToJump = false;
            }
        }

        if (isSelfDestruct)
        {
            StartCoroutine(SelfDestructCoroutine(timeUntilSelfdestruct));
        }
    }

    public void LerpRotationX(float targetRotationX, float time)
    {
        StartCoroutine(LerpRotationXCoroutine(targetRotationX, time));
    }

    private IEnumerator LerpRotationXCoroutine(float targetRotationX, float time)
    {
        //Debug.Log("arranca la corru");
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(targetRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            float t = elapsedTime / time;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que la rotación sea exactamente targetRotationX al final
        transform.rotation = targetRotation;
        //Debug.Log("termine de lerpear rotacion");

    }
}
