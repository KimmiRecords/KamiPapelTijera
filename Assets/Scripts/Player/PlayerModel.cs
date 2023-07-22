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
    Vector3 auxForwardVector;
    float auxOriginalImpulse;


    public PlayerModel(Player player)
    {
        _player = player;
        _playerSpeed = _player.Speed; 
        _speedModifier = 1;
        auxOriginalImpulse = _player.planeoImpulse;
        //initialGravityValue = gravityValue; mismo pero para cambiar la gravedad
    }
    public void NewMove(float hor, float ver)
    {
        bool groundedPlayer = _player.cc.isGrounded;
        if (groundedPlayer)
        {
            _groundedTimer = 0.2f; //mientras este en el suelo
            _player._view.StopJump();
            //_player._view.StartIdleAnimation();
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
            if (_player.augmentedJumpsLeft == 0)
            {
                _player.DestroyPaperPlaneHat();
            }
        }

        _verticalVelocity -= _player.gravityValue * Time.deltaTime; //aplica gravedad extra
        _move = _player.transform.right * hor + _player.transform.forward * ver; //cargo mi vector movimiento


        if (_move.magnitude > 1) //normalizo
        {
            _move = _move.normalized;
        }

        if (_player.isJumpButtonDown)
        {
            if (_groundedTimer > 0)
            {
                _groundedTimer = 0;
                _verticalVelocity += Mathf.Sqrt(_player.jumpForce * 2 * _player.gravityValue); //saltar en realidad le da velocidad vertical nomas
                _player.isJumpButtonDown = false;
                //AudioManager.instance.StopPasos();
                _player._view.StartJumpAnimation();
                //pAnims.StopLanding();
                if (_player.isPaperPlaneHat)
                {
                    Debug.Log("Move: salte con hat. add planing porfaa");
                    _player.AddPlaning();
                    _player.augmentedJumpsLeft--;
                }
            }
        }


        _move *= _playerSpeed * _speedModifier;
        _move.y = _verticalVelocity; //sigo cargando el vector movieminto
        _player.cc.Move(_move * Time.deltaTime); //aplico el vector movieminto al character controller, con el metodo .Move

        if (hor != 0 || ver != 0)
        {
            _player._view.RotateModel(_move);
        }

        //Debug.Log(_move);
    }

    public void Transportar(Vector3 move)
    {
        //Debug.Log("player Model: transportar");
        _player.cc.Move(move * Time.deltaTime);
        //_player.cc.Move(auxForwardVector, auxForwardVector);
    }


    public void EnableTijeraHitbox()
    {
        //Debug.Log("prendo la tijera");
        _player.miTijeraHitbox.gameObject.SetActive(true);
    }

    public void DisableTijeraHitbox()
    {
        //Debug.Log("apago la tijera");
        _player.miTijeraHitbox.gameObject.SetActive(false);
    }

    //public IEnumerator AddExtraForwardForce(float delayTime, float duration, float decayRate)
    //{
    //    yield return new WaitForSeconds(delayTime);

    //    auxTimer = 0;
    //    _player.planeoImpulse = auxOriginalImpulse;

    //    while (auxTimer < duration)
    //    {
    //        auxForwardVector = _player.lastDirection * _player.planeoImpulse;
    //        _player.cc.Move(auxForwardVector * Time.deltaTime);
    //        _player.planeoImpulse *= (1 - decayRate);
    //        auxTimer += Time.deltaTime;
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    

    public IEnumerator AddExtraForwardForce(float delayTime, float duration)
    {
        yield return new WaitForSeconds(delayTime);

        _player.planeoImpulse = auxOriginalImpulse;
        float elapsedTime = 0f;
        float startImpulse = _player.planeoImpulse;

        while (elapsedTime < duration)
        {
            auxForwardVector = _player.lastDirection * _player.planeoImpulse;
            _player.cc.Move(auxForwardVector * Time.deltaTime);

            // Reducci�n lineal del planeoImpulse en funci�n del tiempo transcurrido
            _player.planeoImpulse = Mathf.Lerp(startImpulse, 0f, elapsedTime / duration);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        // Asegurarse de que el planeoImpulse sea exactamente 0 al final de la corrutina
        _player.planeoImpulse = 0f;
    }
}
