using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitud de oscilaci�n
    public float frequency = 1f; // Frecuencia de oscilaci�n

    private Vector3 startPosition;

    private void Start()
    {
        // Guarda la posici�n inicial del GameObject
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calcula la posici�n en el eje Y utilizando una funci�n sinusoidal
        float newY = startPosition.y + amplitude * Mathf.Sin(frequency * Time.time);

        // Actualiza la posici�n del GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}