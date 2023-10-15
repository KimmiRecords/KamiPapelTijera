using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPaperCostTextUpdater : TextUpdater
{
    [SerializeField] Color colorWhenNotEnoughPaper;
    [SerializeField] TriggerOrigami triggerOrigami;

    int paperCost;
    int currentPaperAmount = 0;
    Color originalColor;

    private void OnEnable()
    {
        //Debug.Log("on enable");
        if (LevelManager.Instance != null)
        {
            currentPaperAmount = LevelManager.Instance.recursosRecolectados[ResourceType.papel];
        }
        paperCost = triggerOrigami.origami.paperCost;
        originalColor = myText.color;
        SetText(currentPaperAmount, paperCost);
    }

    protected override void UpdateText(params object[] parameter)
    {
        //Debug.Log("update text");
        //me interesa resourceupdate, que param1 es amount
        if ((ResourceType)parameter[0] == ResourceType.papel)
        {
            currentPaperAmount = (int)parameter[1];
            SetText(currentPaperAmount, paperCost);
        }
    }

    public void SetText(int currentAmount, int cost)
    {
        //Debug.Log("set text");
        
        myText.text = textoInicial + currentAmount.ToString() + " / " + cost.ToString();
        myText.color = CheckFontColor(currentAmount, cost);
    }

    Color CheckFontColor(int currentAmount, int cost)
    {
        //Debug.Log("check font color");
        Color resultColor = originalColor;

        if (currentAmount < cost || triggerOrigami.origami.wasUsed)
        {
            //Debug.Log("colorWhenNotEnoughPaper");
            resultColor = colorWhenNotEnoughPaper;
        }

        return resultColor;
    }
}
