using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBManager : Singleton<PUBManager>
{
    //bueno la idea es asi
    //cuando cambia la pagina, nace el objeto
    //los objetos cuando nacen, nacen con su animacion de ABRIRSE  
    //cuando cambia la pagina nuevamente, disparan su animacion de CERRARSE y mueren
    //como sabe el pagescroller que esta animacion terminó?

    //para abrir no hace falta nada, porque nacen y se abren de una. 
    //pero para cerrar, si

    [SerializeField] List<PUB> pubs = new List<PUB>();

    public void OpenPUBs()
    {
        foreach (PUB pub in pubs)
        {
            pub.OpenPUB();
        }
    }
    public void ClosePUBs()
    {
        foreach (PUB pub in pubs)
        {
            pub.ClosePUB();
        }
    }
    public void AddPUB(PUB pub)
    {
        if (!pubs.Contains(pub))
        {
            pubs.Add(pub);
            //print("agregaste el pub " + pub.gameObject.name);
        }
    }
    public void RemovePUB(PUB pub)
    {
        pubs.Remove(pub);
        //print("removiste el pub " + pub.gameObject.name);
    }
}
