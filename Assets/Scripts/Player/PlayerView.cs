using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView
{
    Animator _anim;
    Player _player;
    bool canRotate;
    Vector3 lastDirection = Vector3.zero;

    public PlayerView(Player player)
    {
        _anim = player.anim;
        _player = player;
    }

    public void CheckMagnitude(float hor, float ver)
    {
        if (hor == 0 && ver == 0)
        {
            StartIdleAnimation();
            canRotate = false;
        }
        else
        {
            StartMoveAnimation();
            canRotate = true;
        }
    }

    public void RotateModel(Vector3 move)
    {
        if (canRotate)
        {
            lastDirection = new Vector3(move.x, _anim.transform.forward.y, move.z);
            _anim.transform.forward = lastDirection;
        }
    }

    public void StartTijeraAnimation()
    {
        AudioManager.instance.PlayByName("TijeraMiss", 1.1f);
        //_anim.SetTrigger("TijeraAttack01");
        _anim.SetTrigger("isAtack");
    }

    public void StartGetWetAnimation()
    {
        AudioManager.instance.PlayByName("ShipCrash", 0.4f);
    }

    public void StartGetGolpeadoAnimation()
    {
        AudioManager.instance.PlayByName("ShipCrash", 0.75f);
    }

    public void StartMoveAnimation()
    {
        _anim.SetBool("isWalk", true);
    }

    public void StartIdleAnimation()
    {
        _anim.SetBool("isWalk", false);
        _anim.SetTrigger("Idle");
    }

    public void StartJumpAnimation()
    {
        AudioManager.instance.PlayByName("JumpSFX", 2f);
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isJump", true);    
    }

    public void StopJump()
    {
        _anim.SetBool("isJump", false);
    }
}
