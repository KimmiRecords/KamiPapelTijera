using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Solapa : MonoBehaviour
{
    protected bool isOn;

    protected Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void CambiarEstado()
    {
        isOn = !isOn;
    }

    

    
}
