using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoCortable : MonoBehaviour
{
    //los objetosCortables se pueden partir en dos
    //la parte de arriba sale volando y se convierte en pickup

    public float respawnTime = 5;

    public SpriteRenderer spriteEntero, spriteBase;
    public SpritePickup spritePickup;
    public Rigidbody pickupRB;

    bool isCortable = true;

    public void GetCut(float dmg)
    {
        if (isCortable)
        {
            print("cortaste este arbusto");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

            //apago el entero y prendo las partes
            spriteEntero.gameObject.SetActive(false);
            spriteBase.gameObject.SetActive(true);
            pickupRB.gameObject.SetActive(true);

            //el pickup pega saltito y cae wujuuuu
            spritePickup.Jump();
            StartDelayedRespawn();

            isCortable = false;
        }
    }

    public void StartDelayedRespawn()
    {
        print("start delayed respawn");

        StopAllCoroutines();
        StartCoroutine(DelayedRespawn());
    }
    public IEnumerator DelayedRespawn()
    {
        //print("delayed respawn");

        yield return new WaitForSeconds(respawnTime);
        Respawn();
    }
    public void Respawn()
    {
        print("respawn");

        //dejo preparado el nuevo pickup
        spritePickup.ResetPosition();

        //apago las partes y prendo el entero
        spriteBase.gameObject.SetActive(false);
        pickupRB.gameObject.SetActive(false);
        spriteEntero.gameObject.SetActive(true);
        isCortable = true;
    }

}
