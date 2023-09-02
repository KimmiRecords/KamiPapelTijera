using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorCortable : ObjetoCortable
{
    //cuando cortas una flor con la tijera, se parte en 2 y la mitad de arriba se cae

    //public SpritePickup spritePickup;

    //[SerializeField] protected ResourceType pickupType;
    //[SerializeField] protected int pickupAmount = 1;

    //public bool ListoParaCortar
    //{
    //    get
    //    {
    //        return isCortable;
    //    }
    //    set
    //    {
    //        isCortable = value;
    //    }
    //}
        

    //private void Start()
    //{
    //    if (spriteTop.GetComponent<SpritePickup>() != null)
    //    {
    //        spritePickup = spriteTop.GetComponent<SpritePickup>();
    //    }
    //}

    //public override void GetCut(float dmg)
    //{
    //    if (isCortable)
    //    {
    //        //print("cortaste este arbusto");
    //        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
    //        AudioManager.instance.PlayRandom("PaperCut01", "PaperCut02");

    //        //apago el entero y prendo las partes
    //        spriteEntero.gameObject.SetActive(false);
    //        spriteBase.gameObject.SetActive(true);
    //        pickupRB.gameObject.SetActive(true);

    //        //el pickup pega saltito y cae wujuuuu
    //        spritePickup.Jump();

    //        //en vez de delayedspawn, es instapickup
    //        //StartDelayedRespawn();
    //        LevelManager.Instance.AddResource(pickupType, pickupAmount);
    //        AudioManager.instance.PlayByName("PickupSFX");
    //        isCortable = false;
    //    }
    //}


    ////estos 3 por ahora nmo se usan pues las flores/hongos no respawnean
    //public void StartDelayedRespawn()
    //{
    //    //print("start delayed respawn");

    //    StopAllCoroutines();
    //    StartCoroutine(DelayedRespawn());
    //}
    //public IEnumerator DelayedRespawn()
    //{
    //    //print("delayed respawn");

    //    yield return new WaitForSeconds(respawnTime);
    //    Respawn();
    //}
    //public virtual void Respawn()
    //{
    //    //print("respawn");

    //    spritePickup.ResetPosition();

    //    //apago las partes y prendo el entero
    //    spriteBase.gameObject.SetActive(false);
    //    pickupRB.gameObject.SetActive(false);
    //    spriteEntero.gameObject.SetActive(true);
    //    isCortable = true;
    //    //_isCortado = false;
    //}
}
