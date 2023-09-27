using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public int amount;
    public ResourceType resourceType;
    //public bool isRecortable;
    //public InventoryItem possibleCutChild;
}
