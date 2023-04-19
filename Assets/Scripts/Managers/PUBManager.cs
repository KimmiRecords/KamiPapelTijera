using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUBManager : MonoBehaviour
{
    //bueno la idea es asi
    //cuando cambia la pagina, nace el objeto
    //los objetos cuando nacen, nacen con su animacion de ABRIRSE  
    //cuando cambia la pagina nuevamente, disparan su animacion de CERRARSE y mueren
    //como sabe el pagescroller que esta animacion terminó?

    //para abrir no hace falta nada, porque nacen y se abren de una. 
    //pero para cerrar, si

    public static PUBManager instance;

    [SerializeField]
    List<PUB> pubs = new List<PUB>();


    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        //EventManager.Subscribe(Evento.OnPlayerChangePage, ChangePage);
    }

    //public void ChangePage(params object[] parameter)
    //{
    //    if (parameter[0] is int)
    //    {
    //        foreach (PUB pub in pubs)
    //        {
    //            if (pub.pagina == (int)parameter[0])
    //            {
    //                pub.OpenPUB();
    //                print("abri los pubs");
    //            }
    //            else
    //            {
    //                pub.ClosePUB();
    //                print("cerre los pubs");

    //            }
    //        }
    //    }
    //}

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
        //else
        //{
        //    //print("el pub " + pub.gameObject.name + " ya estaba en la lista");
        //}
    }
    public void RemovePUB(PUB pub)
    {
        pubs.Remove(pub);
        //print("removiste el pub " + pub.gameObject.name);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            //EventManager.Unsubscribe(Evento.OnPlayerChangePage, ChangePage);
        }
    }

}
