using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCortable : MonoBehaviour
{
    public HongoCortable miHongo;
    public Animator anim; //mi animator
    public bool aux = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (miHongo._isCortado && aux)
        {
            anim.SetBool("_isCortado", true);
            aux = false;
        }
    }
}
