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
        if (Input.GetButtonDown("Run"))
        {
            _player.IsSprinting = true;
        }

        if (Input.GetButtonUp("Run"))
        {
            _player.IsSprinting = false;
        }

        if (Input.GetButtonDown("Mute"))
        {
            EventManager.Trigger(Evento.OnPlayerPressedM);
        }

        if (LevelManager.Instance.agency) 
        {
            if (Input.GetButtonDown("Interact"))
            {
                EventManager.Trigger(Evento.OnPlayerPressedE);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _player.OnPrimaryClick();
            }

            if (Input.GetButtonDown("Options"))
            {
                //Application.Quit();
                EventManager.Trigger(Evento.OnPlayerPressedEsc);
            }

            if (Input.GetButtonDown("Inventory"))
            {
                //Application.Quit();
                EventManager.Trigger(Evento.OnPlayerPressedI);
            }

            if (Input.GetButtonDown("Quests"))
            {
                //Application.Quit();
                EventManager.Trigger(Evento.OnPlayerPressedU);
            }

            if (!LevelManager.Instance.inDialogue && !_player.anim.GetBool("isCasting")) //este if mepa que va en model
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _player.isJumpButtonDown = true;
                    EventManager.Trigger(Evento.OnPlayerPressedSpace); 
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
}
