using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class FlapDisplayButton : MonoBehaviour
{
    //tienen 2 sprites q cambian segun que esta mostrando el flap

    [SerializeField] Sprite inactive, active;
    Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Activate()
    {
        Debug.Log("muestro el activado");
        _image.sprite = active;
    }

    public void Deactivate()
    {
        Debug.Log("muestro el inactivado");
        _image.sprite = inactive;
    }
}
