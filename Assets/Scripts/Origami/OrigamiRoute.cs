using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiRoute : MonoBehaviour
{
    public RectTransform inicioRectangle;
    public RectTransform[] routeRectangles;
    public RectTransform finalRectangle;

    [HideInInspector]
    public bool wasCompleted;
}
