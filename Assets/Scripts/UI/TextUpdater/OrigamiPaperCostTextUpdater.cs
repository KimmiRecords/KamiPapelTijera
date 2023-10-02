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


    private void Start()
    {
        paperCost = triggerOrigami.origami.paperCost;
        originalColor = myText.color;
        myText.text = textoInicial + currentPaperAmount.ToString() + " / " + paperCost.ToString();
        myText.color = CheckFontColor(currentPaperAmount, paperCost);
    }

    protected override void UpdateText(params object[] parameter)
    {
        //me interesa resourceupdate, que param1 es amount
        if ((ResourceType)parameter[0] == ResourceType.papel)
        {
            currentPaperAmount = (int)parameter[1];
            myText.text = textoInicial + currentPaperAmount.ToString() + " / " + paperCost.ToString();
            myText.color = CheckFontColor(currentPaperAmount, paperCost);
        }
    }

    Color CheckFontColor(int currentAmount, int cost)
    {
        Color resultColor = originalColor;

        if (currentAmount < cost || triggerOrigami.origami.wasUsed)
        {
            resultColor = colorWhenNotEnoughPaper;
        }

        return resultColor;
    }
}
