using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorCortable : ObjetoCortable, ICortable
{
    //cuando cortas una flor con la tijera, se parte en 2 y la mitad de arriba se cae
    //una vez en el piso, la mitad de arriba es pickupeable

    public float respawnTime = 5;
    public SpritePickup spritePickup;

    private void Start()
    {
        if (spriteTop.GetComponent<SpritePickup>() != null)
        {
            spritePickup = spriteTop.GetComponent<SpritePickup>();
        }
    }

    public override void GetCut(float dmg)
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
