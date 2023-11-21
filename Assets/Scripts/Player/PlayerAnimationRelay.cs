using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationRelay : MonoBehaviour
{
    //este script se lo pones al objeto que tenga el animator del player
    //asi las timeline de las animaciones pueden disparar metodos del player directo

    public Player player;

    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }    
    }

    public void StartTijeraCoroutine()
    {
        player.StartTijeraCoroutine();
    }

    public void SetIsAttackingOn()
    {
        player.isAttacking = true;
        //print("isAttacking es " + player.isAttacking);

    }
    public void SetIsAttackingOff()
    {
        player.isAttacking = false;
        //print("isAttacking es " + player.isAttacking);
    }

    public void StartPasoSFX(int step)
    {
        player.StartPasoSFX(step);
    }

    public void StartTijeraParticles()
    {
        player.StartTijeraParticles();
    }

    public void StopTijeraParticles()
    {
        player.StopTijeraParticles();
    }
}
