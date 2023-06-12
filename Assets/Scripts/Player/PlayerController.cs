using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    //solo recibo ordenes
    //getaxis es wasd o flechitas. eso es solo para moverse, asi que los mando directo al player
    //los demas, como seguro hacen distintas cosas en distintos objetos (no solo en player), los hago disparar eventos globales

    public float hor;
    public float ver;

    Player _player;

    public PlayerController(Player player)
    {
        _player = player;
    }

    public void CheckControls() //a este lo disparo en el update
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Trigger(Evento.OnPlayerPressedE);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventManager.Trigger(Evento.OnPlayerPressedQ);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _player.OnPrimaryClick();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!LevelManager.instance.inDialogue && !_player.isAttacking)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _player.isJumpButtonDown = true;
            }

            if (Input.GetButtonUp("Jump"))
            {
                _player.isJumpButtonDown = false;
            }

            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
        }
        else
        {
            hor = 0;
            ver = 0;
        }
    }
}
