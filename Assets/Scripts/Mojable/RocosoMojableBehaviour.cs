using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocosoMojableBehaviour : MonoBehaviour, IMojable
{
    public Rocoso rocoso;

    public void GetWet(float wetDamage)
    {
        rocoso.GetWet(wetDamage);
    }

    public void StopGettingWet()
    {
        rocoso.StopGettingWet();
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
