using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCameraRotation : MonoBehaviour
{
    Quaternion rotacionInicial;

    private void Start()
    {
        rotacionInicial = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = rotacionInicial;
    }
}
