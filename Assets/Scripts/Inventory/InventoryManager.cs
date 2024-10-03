using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    [SerializeField] GameObject _inventorySlotsParent;
    [SerializeField] InventorySlot _showcaseSlot;
    InventorySlot[] _slots;

    [SerializeField] InventoryItem[] _allItems;

    public Dictionary<ResourceType, InventoryItem> itemsByResourceType = new Dictionary<ResourceType, InventoryItem>();

    public Sprite emptyItemSprite;

    private void Start()
    {
        _slots = _inventorySlotsParent.GetComponentsInChildren<InventorySlot>();

        foreach (InventoryItem item in _allItems)
        {
            //check if it wasnt added already
            if (itemsByResourceType.ContainsKey(item.resourceType))
            {
                Debug.Log("ya estaba");
            }

            itemsByResourceType.Add(item.resourceType, item);
        }

        EventManager.Subscribe(Evento.OnResourceUpdated, AddItem);


        //clear all slots
        _showcaseSlot.ClearSlot();
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i].ClearSlot();
        }
    }

    public void ShowcaseItem(InventoryItem item)
    {
        _showcaseSlot.SetItem(item);
    }

    public void AddItem(params object[] parameters)
    {
        ResourceType rt = (ResourceType)parameters[0];
        itemsByResourceType[rt].amount = (int)parameters[1];

        bool shouldClear = false;

        if ((int)parameters[1] <= 0)
        {
            shouldClear = true;
        }

        for (int i = 0; i < _slots.Length; i++)
        {
            //si el ivnentory ya tiene un inventoryslot con el item del tipo q es el resourcetype, actualizo su amount
            if (_slots[i].currentItem == itemsByResourceType[rt]) //si ya esta en inventory, actualizo el amount
            {
                if (shouldClear)
                {
                    _slots[i].ClearSlot();
                    ReorganizeSlots();
                    return;
                }

                _slots[i].currentItem.amount = (int)parameters[1];
                _slots[i].SetItem(_slots[i].currentItem);
                return;
            }

            if (_slots[i].currentItem == null) //si no, lo agrego en el primer slot vacio
            {
                _slots[i].SetItem(itemsByResourceType[rt]);
                return;
            }
        }
    }

    public void ReorganizeSlots()
    {
        List<InventoryItem> nonEmptyItems = new List<InventoryItem>();

        for (int i = 0; i < _slots.Length; i++)
        {
            if (_slots[i].currentItem != null)
            {
                nonEmptyItems.Add(_slots[i].currentItem); //me lleno mi lista aux, borro todos
                _slots[i].ClearSlot();
            }
        }

        for (int i = 0; i < nonEmptyItems.Count; i++)
        {
            _slots[i].SetItem(nonEmptyItems[i]); //lleno de nuevo
        }
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnResourceUpdated, AddItem);
        }
    }

}
