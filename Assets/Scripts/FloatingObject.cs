using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f; // Amplitud de oscilación
    public float frequency = 1f; // Frecuencia de oscilación

    private Vector3 startPosition;

    private void Start()
    {
        // Guarda la posición inicial del GameObject
        startPosition = transform.position;
    }

    private void Update()
    {
        // Calcula la posición en el eje Y utilizando una función sinusoidal
        float newY = startPosition.y + amplitude * Mathf.Sin(frequency * Time.time);

        // Actualiza la posición del GameObject
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}