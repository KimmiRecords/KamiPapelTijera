using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandadoCortable : ObjetoCortable
{
    //el candado dispara la animacion de abrir de un cofreCortable cuando lo corto.
    //[SerializeField] protected float timeUntilDestroy = 5;

    //[SerializeField] protected CofreCortable cofreQueAbro;

    //public override void GetCut(float dmg)
    //{
    //    if (isCortable)
    //    {
    //        print("cortaste este objeto");
    //        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
    //        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

    //        //apago el entero y prendo las partes
    //        spriteEntero.gameObject.SetActive(false);
    //        spriteBase.gameObject.SetActive(true);
    //        pickupRB.gameObject.SetActive(true);

    //        //el pickup pega saltito y cae wujuuuu
    //        pickupRB.AddForce(GetRandomJumpDir() * jumpForce);
    //        isCortable = false;
    //        StartCoroutine(DelayedDestroy());
    //        cofreQueAbro.OpenChest();
    //    }
    //}
    
    //public IEnumerator DelayedDestroy()
    //{
    //    yield return new WaitForSeconds(timeUntilDestroy);
    //    Destroy(gameObject);
    //}
}
