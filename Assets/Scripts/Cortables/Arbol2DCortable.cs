using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol2DCortable : ObjetoCortable
{
    //cuando cortas a este arbol, dispara su animacion
    //y un cambio de camara. seguro tambien sonidos y particulas

    [SerializeField] Animator _anim;
    [SerializeField] GameObject _hitbox;

    bool _falldownEnded;

    protected override void ApplyCut()
    {
        base.ApplyCut();
        CameraManager.Instance.SetCamera(CameraMode.General);
        _anim.SetTrigger("FallDown");
        StartCoroutine(AplastadorHitboxCoroutine());
    }

    public void FinalizarAplastadorHitbox()
    {
        Debug.Log("finalizar aplastador hitbox");
        _falldownEnded = true;
    }

    IEnumerator AplastadorHitboxCoroutine()
    {
        //la idea es que la hitbox solo este prendida mientras cae
        //la animacion de caida me va a avisar cuando termine

        while (!_falldownEnded)
        {
            yield return null;
        }

        Debug.Log("apago la hitbox");
        _hitbox.SetActive(false);
    }

}
