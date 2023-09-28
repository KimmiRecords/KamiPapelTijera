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

    private void Start()
    {
        _slots = _inventorySlotsParent.GetComponentsInChildren<InventorySlot>();

        foreach (InventoryItem item in _allItems)
        {
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
        for (int i = 0; i < _slots.Length; i++)
        {

            //si el ivnentory ya tiene un inventoryslot con el item del tipo q es el resourcetype, actualizo su amount
            if (_slots[i].currentItem == itemsByResourceType[(ResourceType)parameters[0]]) //si ya esta en inventory, sumo 1
            {
                _slots[i].currentItem.amount = (int)parameters[1];
                _slots[i].SetItem(_slots[i].currentItem);
                return;
            }

            if (_slots[i].currentItem == null) //si no, lo agrego en el primer slot vacio
            {
                //_slots[i].currentItem.amount = (int)parameters[1];
                _slots[i].SetItem(itemsByResourceType[(ResourceType)parameters[0]]);
                return;
            }
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
