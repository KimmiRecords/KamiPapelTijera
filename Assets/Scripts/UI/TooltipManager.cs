using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PostItColor
{
    Azul,
    Naranja,
    Rosa,
    Amarillo,
    Verde
}

public class TooltipManager : MonoBehaviour
{
    //por ahora cambia el tooltiptext del player. 

    public static TooltipManager instance;

    [SerializeField]
    PostIt[] postIts;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ShowTooltip(string text, PostItColor postIt)
    {
        postIts[(int)postIt].gameObject.SetActive(true);
        postIts[(int)postIt].tmPro.text = text;
    }

    public void HideTooltip()
    {
        //print("hide tooltip");

        for (int i = 0; i < postIts.Length; i++)
        {
            postIts[i].gameObject.SetActive(false);
            postIts[i].tmPro.text = "";
        }
    }
}
