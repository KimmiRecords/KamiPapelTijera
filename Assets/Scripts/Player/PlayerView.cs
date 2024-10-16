using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

    public void CheckCanRotateModel(Vector3 move)
    {
        if (canRotate)
        {
            RotateModel(move);
        }
    }

    public void RotateModel(Vector3 move)
    {
        _lastDirection = new Vector3(move.x, _anim.transform.forward.y, move.z);
        _anim.transform.forward = _lastDirection;
        _player.lastDirection = _lastDirection;
    }

    public void StartTijeraAnimation()
    {
        _anim.SetTrigger("isAttack");
    }

    public void StartAttack()
    {
        _anim.SetBool("isAttacking", true);
        AudioManager.instance.PlayByName("ActionWind", 1f, 0.01f);
    }

    public void EndAttack()
    {
        _anim.SetBool("isAttacking", false);
    }

    public void StartGetWetAnimation()
    {
        //solo el sonido de arranque
        //los pasos mojados se disparan abajo desde otro metodo
        AudioManager.instance.PlayByName("BigWaterSplash", 1.2f);
    }

    public void StartGetGolpeadoAnimation()
    {
        AudioManager.instance.PlayByName("HurtPaper", 1.2f);
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

    public void StartJumpAnimation(bool isPaperPlaneHat)
    {
        //Debug.Log("anim start jump");
        if (isPaperPlaneHat)
        {
            AudioManager.instance.PlayByName("Jump_Paperplane", 1f, 0.02f);
        }
        AudioManager.instance.PlayByName("JumpStart", 1f, 0.02f);
        _player.particleShooter.Create(1, _anim.transform);
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isJump", true);
    }
    public void StopJump()
    {
        //Debug.Log("anim stop jump");
        _anim.SetBool("isJump", false);
    }

    public void StartFalling()
    {
        //Debug.Log("anim start falling");
        _anim.SetBool("isFalling", true);
    }
    public void StopFalling()
    {
        //Debug.Log("anim stop falling");
        _anim.SetBool("isFalling", false);
    }

    public void StartLanding()
    {
        //Debug.Log("anim start landing");
        _anim.SetBool("isLanding", true);
    }
    public void StopLanding()
    {
        //Debug.Log("anim stop landing");
        _anim.SetBool("isLanding", false);
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
        AudioManager.instance.PlayByName("BootsOn", 2f, 0.01f);
    }

    public void EndSprint()
    {
        _player.particleShooter.Enable(0, false);
        AudioManager.instance.PlayByName("BootsOff", 2f, 0.01f);
    }

    public void StartPasoSFX(int step)
    {
        if (_player.isGettingWet)
        {
            switch (step)
            {
                case 0:
                    AudioManager.instance.PlayRandom("Pasos_KamiMojados_01", "Pasos_KamiMojados_03");
                    break;
                case 1:
                    AudioManager.instance.PlayRandom("Pasos_KamiMojados_02", "Pasos_KamiMojados_04");
                    break;
                default:
                    break;
            }
            _player.particleShooter.Shoot(3); //la 3 es la particula de splash
        }
        else
        {
            switch(step)
            {
                case 0:
                    AudioManager.instance.PlayRandom("Pasos_Kami_01", "Pasos_Kami_03");
                    break;
                case 1:
                    AudioManager.instance.PlayRandom("Pasos_Kami_02", "Pasos_Kami_04");
                    break;
                default:
                    AudioManager.instance.PlayRandom("Pasos_Kami_01", "Pasos_Kami_02", "Pasos_Kami_03", "Pasos_Kami_04");
                    break;
            }
        }

    }

    public void EnableTijeraParticles()
    {
        _player.tijeraParticles.gameObject.SetActive(true);
    }

    public void DisableTijeraParticles()
    {
        _player.tijeraParticles.gameObject.SetActive(false);
    }

    public void StartReceiveReward()
    {
        AudioManager.instance.PlayByName("Receive_Reward");
        CameraManager.Instance.SetCamera(CameraMode.ReceiveReward);
        RotateModel(Vector3.back);
        _anim.SetBool("isReceivingReward", true);
        _player.particleShooter.Enable(2, true);
        //_player.rewardSticker.gameObject.SetActive(true);
        //_player.rewardSticker.StartLerpSequence(_player.rewardAnimationWaitTime);
    }

    

    public void EndReceiveReward()
    {
        CameraManager.Instance.SetCamera(CameraMode.Normal);
        _anim.SetBool("isReceivingReward", false);
        _player.particleShooter.Enable(2, false);
        //_player.rewardSticker.gameObject.SetActive(false);
    }

    internal void StartAffectedByWind(float windForce, Vector3 windDirection)
    {
        Debug.Log("view start affected by wind // windDirection: " + windDirection);
        _player.particleShooter.Enable(4, true);

        //rotate _player.particleShooter.particleSystemGameObject[4] so that it faces the wind direction
        _player.particleShooter.particleSystemGameObject[4].transform.forward = windDirection;


        float minWindForce = 0f;
        float maxWindForce = 0.5f;
        float minParticleSize = 0f;
        float maxParticleSize = 10f;

        float windForceNormalized = (windForce - minWindForce) / (maxWindForce - minWindForce);

        //now scale windforcenormalized to the range of minparticlesize to maxparticlesize
        windForceNormalized = minParticleSize + (windForceNormalized * (maxParticleSize - minParticleSize));

        _player.particleShooter.particleSystemGameObject[4].GetComponent<ParticleSizeUpdater>()?.UpdateSize(windForceNormalized);
        Debug.Log("windforcenormalized = " + windForceNormalized);

    }
    internal void EndAffectedByWind()
    {
        //Debug.Log("view end affected by wind");
        _player.particleShooter.Enable(4, false);
    }

   
}
