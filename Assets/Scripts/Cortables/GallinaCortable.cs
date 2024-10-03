using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaCortable : MonoBehaviour, ICortable
{
    [SerializeField]
    GallinaAI _thisGallina;

    public virtual void GetCut(float dmg)
    {
        print("gallina: me cortaron");
        //AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        //AudioManager.instance.PlayByName("GallinaCluck");
        //_thisGallina.TakeDamage(dmg);
    }
}
