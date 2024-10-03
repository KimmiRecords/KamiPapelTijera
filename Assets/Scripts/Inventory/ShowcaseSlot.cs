using TMPro;
using UnityEngine;

public class ShowcaseSlot : InventorySlot
{
    [SerializeField] TextMeshProUGUI descriptionTextComponent;
    
    override public void SetItem(InventoryItem item)
    {
        base.SetItem(item);
        descriptionTextComponent.text = item.itemDescription;
    }

    override public void ClearSlot()
    {
        base.ClearSlot();
        descriptionTextComponent.text = "";
    }
}
