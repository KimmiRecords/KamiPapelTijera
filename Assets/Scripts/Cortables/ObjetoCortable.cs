using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCortable : MonoBehaviour, ICortable
{
    //los objetosCortables se pueden partir en dos
    //la parte de arriba sale volando

    public float jumpForce = 20f;

    public SpriteRenderer spriteEntero, spriteBase, spriteTop;
    public Rigidbody pickupRB;

    protected bool isCortable = true;


    public virtual void GetCut(float dmg)
    {
        if (isCortable)
        {
            print("cortaste este objeto");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

            //apago el entero y prendo las partes
            spriteEntero.gameObject.SetActive(false);
            spriteBase.gameObject.SetActive(true);
            pickupRB.gameObject.SetActive(true);

            //el pickup pega saltito y cae wujuuuu
            pickupRB.AddForce(GetRandomJumpDir() * jumpForce);
            isCortable = false;
        }
    }

    public Vector3 GetRandomJumpDir()
    {
        float randomX;
        if (Random.Range(0, 100) < 50)
        {
            randomX = -1;
        }
        else
        {
            randomX = 1;
        }

        return new(randomX, 1, randomX);
    }
}
