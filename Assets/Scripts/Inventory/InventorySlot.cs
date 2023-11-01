using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public InventoryItem currentItem;

    [SerializeField] Image itemImageComponent;
    [SerializeField] Image slotStickerImageComponent;
    [SerializeField] TextMeshProUGUI nameTextComponent;
    [SerializeField] TextMeshProUGUI amountTextComponent;



    public virtual void SetItem(InventoryItem item)
    {
        currentItem = item;

        itemImageComponent.sprite = currentItem.itemSprite;
        slotStickerImageComponent.color = currentItem.itemColor;
        nameTextComponent.text = currentItem.itemName;

        if (currentItem.amount < 1)
        {
            ClearSlot();
        }
        else if (currentItem.amount == 1)
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
        itemImageComponent.sprite = InventoryManager.Instance.emptyItemSprite;
        nameTextComponent.text = "";
        amountTextComponent.text = "";
        slotStickerImageComponent.color = Color.white;
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
