using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class PUB : MonoBehaviour
{
    // pub manager llama a metodos de esta clase en vez de decirle "hace tal cosa"

    [SerializeField]
    public int pagina; //de que pagina soy

    Animator _anim;

    bool init = false;

    void Start()
    {
        _anim = GetComponent<Animator>();

        Debug.Log("pub start: adding myself to pubmanager");
        PUBManager.Instance.AddPUB(this);
        init = true;
    }

    public void ClosePUB()
    {
        Debug.Log("close pub");
        _anim.SetBool("isOpen", false);
    }
    
    public void OpenPUB()
    {
        Debug.Log("open pub");
        _anim.SetBool("isOpen", true);
    }

    private void OnEnable()
    {
        if (init)
        {
            Debug.Log("pub enable: init true. adding myself to pubmanager");
            PUBManager.Instance.AddPUB(this);
        }
    }

    private void OnDisable()
    {
        Debug.Log("pub disable: removing myself from pubmanager");
        PUBManager.Instance.RemovePUB(this);
    }
}
