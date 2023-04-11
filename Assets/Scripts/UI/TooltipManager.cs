using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;

    [SerializeField]
    TMPro.TextMeshPro tooltipTextComponent;
    //por ahora cambia texto, pero despues podria cambiar sprites

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
        tooltipTextComponent.gameObject.SetActive(true);
        tooltipTextComponent.text = text;
    }

    public void HideTooltip()
    {
        tooltipTextComponent.gameObject.SetActive(false);
        tooltipTextComponent.text = "";
    }
}
