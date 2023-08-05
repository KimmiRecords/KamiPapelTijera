using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct DialogueEvent
{
    [TextAreaAttribute]
    public string[] texts;
    public Sprite[] sprites;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextAreaAttribute]
    public string[] textos;
    public bool wasRead = false;
    public Sprite sprite;

    //public DialogueEvent[] events;
    //public Sprite[] sprites;
    //public int currentText = 0;
    //Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

}
