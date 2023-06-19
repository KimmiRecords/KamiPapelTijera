using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCortable : MonoBehaviour, ICortable
{
    [SerializeField]
    Entity _thisEntity;

    public virtual void GetCut(float dmg)
    {
        print("entity: me cortaron");
        AudioManager.instance.PlayRandom("TijeraHit01", "TijeraHit02");
        //_thisEntity.TakeDamage(dmg);
    }
}
