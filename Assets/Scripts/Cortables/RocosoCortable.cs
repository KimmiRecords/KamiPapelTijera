using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoCortable : MonoBehaviour, ICortable
{
    [SerializeField] Rocoso _thisRocoso;

    public virtual void GetCut(float receivedDamage)
    {
        if (receivedDamage >= 100) //programming is my passion and this is my code
        {
            //print("rocoso: me cortaron");
            AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
            _thisRocoso.TakeDamage(receivedDamage);
        }
    }

}
