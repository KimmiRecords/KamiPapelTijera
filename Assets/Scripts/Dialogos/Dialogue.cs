using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct DialogueEvent
{
    [TextAreaAttribute]
    public string text;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextAreaAttribute]
    public string[] textos;
    public bool wasRead = false;
    public Sprite sprite;

    public DialogueEvent[] events;
    public int currentText = 0;
}
