using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    //en realidad al sprite no le hace nada. rota al objeto y ya.
    //se suscribe al evento onMove para enterarse de eso sin depender de nadie

    float previousDirection = 0;
    float currentDirection;

    private void Start()
    {
        //previousDirection = 0;
        EventManager.Subscribe(Evento.OnPlayerMove, FlipSprite);
    }

    void FlipSprite(params object[] parameter)
    {
        if (!(parameter[0] is float))
        {
            return;
        }

        if ((float)parameter[0] != 0)
        {
            currentDirection = (float)parameter[0];
        }

        if (currentDirection != previousDirection)
        {
            float rotationAngle = (currentDirection < 0) ? 180f : 0f;

            transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);
            previousDirection = currentDirection;
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerMove, FlipSprite);
        }
    }
}
