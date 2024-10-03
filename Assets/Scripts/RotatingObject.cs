using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float velocidadRotacionX = 5f;
    public float velocidadRotacionY = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * velocidadRotacionX * Time.deltaTime);
        transform.Rotate(Vector3.up * velocidadRotacionY * Time.deltaTime);
    }
}
