using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    //el Model del playerMVC
    //aca en model dice que hace move y jump, y van a estar otras mecanicas seguramente

    Player _player;

    float _groundedTimer;
    float _verticalVelocity;
    float _speedModifier;
    float _playerSpeed;

    Vector3 _move; //el vector en el que guardo la suma de todo el movimiento para finalmente aplicarsela al character controller

    public PlayerModel(Player player)
    {
        _player = player;

        _playerSpeed = _player.walkingSpeed; 
        _speedModifier = 1;
        //initialGravityValue = gravityValue; mismo pero para cambiar la gravedad

    }

    public void NewJump()
    {
        Debug.Log("salto");
    }


    public void NewMove(float hor, float ver)
    {
        bool groundedPlayer = _player.cc.isGrounded;
        if (groundedPlayer)
        {
            _groundedTimer = 0.2f; //mientras este en el suelo
            //pAnims.StopJumping();
            //pAnims.StopFalling();
            //pAnims.PlayLanding();
        }

        if (_groundedTimer > 0)
        {
            _groundedTimer -= Time.deltaTime;
        }

        //if (!groundedPlayer && _verticalVelocity <= -2f) //si esta cayendo pero no tocando el suelo empieza a caer
        //{
        //    pAnims.StopJumping();
        //    pAnims.PlayFalling();
        //}

        if (groundedPlayer && _verticalVelocity <= 0) //corta la caida cuando toco el suelo
        {
            _verticalVelocity = 0f;
            //AudioManager.instance.PlayJumpDown();
        }

        _verticalVelocity -= _player.gravityValue * Time.deltaTime; //aplica gravedad extra
        _move = _player.transform.right * hor + _player.transform.forward * ver; //cargo mi vector movimiento


        if (_move.magnitude > 1) //normalizo
        {
            _move = _move.normalized;
        }

        if (_player.isJump)
        {
            if (_groundedTimer > 0)
            {
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(_player.jumpForce * 2 * _player.gravityValue); //saltar en realidad le da velocidad vertical nomas
                _player.isJump = false;
                //AudioManager.instance.StopPasos();
                //AudioManager.instance.PlayJumpUp();
                //pAnims.PlayJumping();
                //pAnims.StopLanding();
            }
        }

        _move *= _playerSpeed * _speedModifier;
        _move.y = _verticalVelocity; //sigo cargando el vector movieminto
        _player.cc.Move(_move * Time.deltaTime); //aplico el vector movieminto al character controller, con el metodo .Move

        //if (agency) //esto es para cosass de la aanimacion
        //{
        //    pAnims.CheckMagnitude(_move.x + _move.z); //en el script de playerAnimations, chequea si me estoy moviendo o no
        //}
    }
}
