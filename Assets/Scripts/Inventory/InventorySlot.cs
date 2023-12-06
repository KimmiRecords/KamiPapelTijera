using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem currentItem;

    [SerializeField] protected Image itemImageComponent;
    [SerializeField] protected Image slotStickerImageComponent;
    [SerializeField] protected TextMeshProUGUI nameTextComponent;
    [SerializeField] protected TextMeshProUGUI amountTextComponent;

    protected Color _originalTextColor, _originalSlotColor, _originalIconColor;
    public float upwardsSpeed = 100;



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

    public virtual void BUTTON_OnHover()
    {
        AudioManager.instance.PlayByName("Action_Hover", 1);
    }

    public virtual void BUTTON_OnPress()
    {
        AudioManager.instance.PlayByName("PaperFold01", 3f, 0.05f);
        if (currentItem != null)
        {
            InventoryManager.Instance.ShowcaseItem(currentItem);
        }
    }

    public void StartLerpSequence(float duration)
    {
        StartCoroutine(AlphaLerpSequence(duration));
    }
    public IEnumerator AlphaLerpSequence(float duration)
    {
        StartCoroutine(AlphaLerpFadeIn(duration));
        yield return new WaitForSeconds(duration * 2);
        StartCoroutine(AlphaLerpFadeOut(duration));
    }
    public IEnumerator AlphaLerpFadeIn(float duration)
    {
        float elapsedTime = 0;
        SetTransparency(0);

        while (elapsedTime < duration)
        {
            SetTransparency(Mathf.Lerp(0, 1, elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator AlphaLerpFadeOut(float duration)
    {
        float elapsedTime = 0;
        SetTransparency(1);

        while (elapsedTime < duration)
        {
            SetTransparency(Mathf.Lerp(1, 0, elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ResourceParticleManager.Instance.isShowingRewardSticker = false;
    }



}
