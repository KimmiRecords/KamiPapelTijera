using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public InventoryItem currentItem;

    [SerializeField] Image imageComponent;
    [SerializeField] TextMeshProUGUI nameTextComponent;
    [SerializeField] TextMeshProUGUI amountTextComponent;


    public virtual void SetItem(InventoryItem item)
    {
        currentItem = item;

        imageComponent.sprite = currentItem.itemSprite;
        nameTextComponent.text = currentItem.itemName;

        if (currentItem.amount <= 1)
        {
            amountTextComponent.text = "";
        }
        else
        {
            amountTextComponent.text = currentItem.amount.ToString();
        }
    }

    public virtual void ClearSlot()
    {
        currentItem = null;
        imageComponent.sprite = null;
        nameTextComponent.text = "";
        amountTextComponent.text = "";
    }


    public virtual void BTN_OnPress()
    {
        AudioManager.instance.PlayByName("PaperFold01", 3f, 0.05f);
        if (currentItem != null)
        {
            InventoryManager.Instance.ShowcaseItem(currentItem);
        }
    }



   
}
