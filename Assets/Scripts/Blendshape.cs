using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blendshape : MonoBehaviour
{

    public void OnOpenAnimationStart()
    {
        //CasaManager.instance.PonerCasaLowPoly();
    }

    public void OnOpenAnimationEnd()
    {
        CasaManager.instance.PonerCasaHighPoly();
    }

    public void OnCloseAnimationStart()
    {
        CasaManager.instance.PonerCasaLowPoly();
    }

    public void OnCloseAnimationEnd()
    {
        //CasaManager.instance.PonerCasaHighPoly();
    }
}
