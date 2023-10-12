using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView
{
    Animator _anim;
    Player _player;
    bool canRotate;
    Vector3 _lastDirection = Vector3.zero;
    public bool tabIsPressed;

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
            _lastDirection = new Vector3(move.x, _anim.transform.forward.y, move.z);
            _anim.transform.forward = _lastDirection;
            _player.lastDirection = _lastDirection;
        }
    }

    public void StartTijeraAnimation()
    {
        _anim.SetTrigger("isAttack");
    }

    public void StartAttack()
    {
        _anim.SetBool("isAttacking", true);
    }

    public void EndAttack()
    {
        _anim.SetBool("isAttacking", false);
    }

    public void StartGetWetAnimation()
    {
        AudioManager.instance.PlayByName("BigWaterSplash", 1.4f);
        //triggerear loop de particulas
        //triggerear loop de sonido de nadar splashsplash
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
        AudioManager.instance.PlayByName("JumpSFX", 2f, 0.05f);
        _player.particleShooter.Create(1, _anim.transform);
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isJump", true);
    }

    public void StopJump()
    {
        _anim.SetBool("isJump", false);
    }

    public void StartCast()
    {
        _anim.SetBool("isCasting", true);
    }

    public void EndCast()
    {
        _anim.SetBool("isCasting", false);
    }

    public void StartSprint()
    {
        _player.particleShooter.Enable(0, true);
        AudioManager.instance.PlayByName("JumpSFX", 1.5f);
    }

    public void EndSprint()
    {
        _player.particleShooter.Enable(0, false);
        AudioManager.instance.PlayByName("JumpSFX", 1.2f);
    }
}
