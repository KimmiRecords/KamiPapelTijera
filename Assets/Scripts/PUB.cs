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
        PUBManager.Instance.AddPUB(this);
        init = true;
    }

    public void ClosePUB()
    {
        //_anim.Play("CasaDown");
        _anim.SetBool("isOpen", false);
    }
    
    public void OpenPUB()
    {
        //_anim.Play("CasaUp");
        _anim.SetBool("isOpen", true);
    }

    private void OnEnable()
    {
        if (init)
        {
            PUBManager.Instance.AddPUB(this);
        }
    }

    private void OnDisable()
    {
        PUBManager.Instance.RemovePUB(this);
    }
}
