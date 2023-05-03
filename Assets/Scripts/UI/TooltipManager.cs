using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    //por ahora cambia el tooltiptext del player. 

    public static TooltipManager instance;

    [SerializeField]
    TMPro.TextMeshProUGUI tooltipTextComponent;

    [SerializeField]
    GameObject tooltipObject;

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


    public void ShowTooltip(string text)
    {
        tooltipObject.SetActive(true);
        tooltipTextComponent.text = text;
    }

    public void HideTooltip()
    {
        //print("hide tooltip");
        tooltipObject.SetActive(false);
        tooltipTextComponent.text = "";
    }
}
