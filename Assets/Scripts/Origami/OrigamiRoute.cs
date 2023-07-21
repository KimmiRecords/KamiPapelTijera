using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiRoute : MonoBehaviour
{
    public RectTransform inicioRectangle;
    //public RectTransform[] routeRectangles;
    public List<RectTransform> routeRectangles;
    public RectTransform finalRectangle;

    [HideInInspector]
    public bool wasCompleted;

    private void Start()
    {
        routeRectangles.Add(inicioRectangle);
        routeRectangles.Add(finalRectangle);
        print("agregue los rectangulos inicio y fin a la lista");
    }
}
