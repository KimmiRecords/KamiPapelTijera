using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObjects/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemSprite;
    public Color itemColor; //para q cambie el color del sticker jeje :P
    public ResourceType resourceType;
    //public int amount;
    //public bool isRecortable;
    //public InventoryItem possibleCutChild;
}
