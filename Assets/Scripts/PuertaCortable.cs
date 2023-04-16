using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCortable : MonoBehaviour, ICortable
{
    public void GetCut(float dmg)
    {
        print("cortaste la puerta");
        Destroy(gameObject);
    }
}
