using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamWheelButton : MonoBehaviour
{
    [HideInInspector] public Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }
}
