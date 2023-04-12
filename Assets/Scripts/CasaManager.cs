using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasaManager : MonoBehaviour
{
    public static CasaManager instance;

    [SerializeField]
    GameObject casaLowPoly;
    [SerializeField]
    GameObject casaHighPoly;

    [SerializeField]
    Animator _casaLowPolyAnim;


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
        EventManager.Subscribe(Evento.OnPlayerChangePage, ChangePage);
        PonerCasaLowPoly();

        if (!_casaLowPolyAnim)
        {
            _casaLowPolyAnim = casaLowPoly.GetComponentInChildren<Animator>();
        }
    }


    public void PonerCasaHighPoly()
    {
        casaHighPoly.SetActive(true);
        casaLowPoly.SetActive(false);
    }

    public void PonerCasaLowPoly()
    {
        casaLowPoly.SetActive(true);
        casaHighPoly.SetActive(false);
    }

    public void ChangePage(params object[] parameter)
    {
        PonerCasaLowPoly();
        _casaLowPolyAnim.Play("CasaDown");
        _casaLowPolyAnim.SetBool("isOpen", false);

    }
}
