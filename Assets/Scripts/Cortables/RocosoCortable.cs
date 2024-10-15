using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoCortable : MonoBehaviour, ICortable
{
    [SerializeField] Rocoso _thisRocoso;
    [SerializeField] bool _isImmuneToTijeraMejorada = false;

    public virtual void GetCut(float receivedDamage)
    {
        if (receivedDamage >= 100 && !_isImmuneToTijeraMejorada) //programming is my passion and this is my code
        {
            //print("rocoso: me cortaron");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            _thisRocoso.TakeDamage(receivedDamage);
        }
    }

}
