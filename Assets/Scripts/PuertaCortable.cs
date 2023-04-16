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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
