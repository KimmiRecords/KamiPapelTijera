using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCortable : MonoBehaviour, ICortable
{
    //los objetosCortables se pueden partir en dos
    //la parte de arriba sale volando

    //[SerializeField] protected float jumpForce = 5;
    [SerializeField] protected SpriteRenderer spriteEntero, spriteBase, spriteTop;
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
            spriteTop.gameObject.SetActive(true);

            //el pickup pega saltito y cae wujuuuu
            //spriteTop.gameObject.transform.position += GetRandomJumpDir() * jumpForce;
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

        return new(randomX, 1, -1);
    }
}
