using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //player esta partido en 4. aca solo pongo lo que quiero que pase. 
    //model se encarga de pensar, controller de recibir los controles, y view de animaciones, sonidos, particulas etc
    //aca contruyo a los 3, y les paso mi refe. ellos hablan conmigo, no entre ellos.
    //ademas, yo tengo start y update, ellos no.

    public float walkingSpeed = 5f;
    public float jumpForce = 50f;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto

    public CharacterController cc;

    [HideInInspector]
    public bool isJump;

    PlayerModel _model;
    PlayerController _controller;


    void Start()
    {
        _model = new PlayerModel(this);
        _controller = new PlayerController(this);
    }

    private void Update()
    {
        _controller.CheckControls();

        if (_controller.hor != 0 || _controller.ver != 0)
        {
            //print(_controller.hor + "//" + _controller.ver);
            EventManager.Trigger(Evento.OnPlayerMove, _controller.hor, _controller.ver);
        }

        _model.NewMove(_controller.hor, _controller.ver); //todo el tiempo, aunque no me mueva, pues caidas y bla
    }
}
