using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public enum Speaker
//{
//    norberto,
//    tiburcio,
//    dalia,
//    abuela,
//    narrador,
//    chino,
//    farolio,
//}


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [TextAreaAttribute]
    public string[] textos;
    public bool wasRead = false;
    public Sprite sprite;
}
