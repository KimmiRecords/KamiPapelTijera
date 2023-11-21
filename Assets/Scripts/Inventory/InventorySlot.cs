using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InventorySlot : MonoBehaviour
{
    public InventoryItem currentItem;

    [SerializeField] protected Image itemImageComponent;
    [SerializeField] protected Image slotStickerImageComponent;
    [SerializeField] protected TextMeshProUGUI nameTextComponent;
    [SerializeField] protected TextMeshProUGUI amountTextComponent;

    protected Color _originalTextColor, _originalSlotColor, _originalIconColor;


    private void Start()
    {
        _originalTextColor = nameTextComponent.color;
        _originalSlotColor = slotStickerImageComponent.color;
        _originalIconColor = itemImageComponent.color;
    }

    public void SetTransparency(float alpha)
    {
        //Debug.Log("set transparency");
        nameTextComponent.color = new Color(nameTextComponent.color.r, nameTextComponent.color.g, nameTextComponent.color.b, alpha);
        slotStickerImageComponent.color = new Color(slotStickerImageComponent.color.r, slotStickerImageComponent.color.g, slotStickerImageComponent.color.b, alpha);
        itemImageComponent.color = new Color(itemImageComponent.color.r, itemImageComponent.color.g, itemImageComponent.color.b, alpha);
    }

    public void ResetColor()
    {
        //Debug.Log("reset color");
        nameTextComponent.color = _originalTextColor;
        slotStickerImageComponent.color = _originalSlotColor;
        itemImageComponent.color = _originalIconColor;
    }

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
