using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FlapDisplayButton : MonoBehaviour
{
    //tienen 2 sprites q cambian segun que esta mostrando el flap

    [SerializeField] Sprite inactive, active;
    [SerializeField] Image _imageOnOff;
    
    public void Activate()
    {
        //Debug.Log("muestro el activado");
        _imageOnOff.sprite = active;
    }

    public void Deactivate()
    {
        //Debug.Log("muestro el inactivado");
        _imageOnOff.sprite = inactive;
    }
}
