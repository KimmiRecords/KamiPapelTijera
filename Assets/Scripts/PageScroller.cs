using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
    //a este singleton le pones los gameobjectpadre que contienen todo lo de su pagina gg

    public static PageScroller instance;

    [SerializeField]
    private GameObject[] objectsToToggle;
    private int activeIndex = 0;

    public TriggerScript esferaPrev;
    public TriggerScript esferaNext;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        EventManager.Subscribe(Evento.OnPlayerPressedQ, TurnPrevPage);
        EventManager.Subscribe(Evento.OnPlayerPressedE, TurnNextPage);

    }

    void TurnNextPage(params object[] parameters)
    {
        if (esferaNext.triggerBool)
        {
            if (activeIndex >= objectsToToggle.Length - 1)
            {
                print("no hay mas paginas");
            }
            else
            {
                activeIndex++;
                SetActiveObject();
            }
        }
    }

    void TurnPrevPage(params object[] parameters)
    {
        if (esferaPrev.triggerBool)
        {
            if (activeIndex <= 0)
            {
                print("no hay mas paginas");
            }
            else
            {
                activeIndex--;
                SetActiveObject();
            }
        }
    }

    private void SetActiveObject()
    {
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            if (i == activeIndex)
            {
                objectsToToggle[i].SetActive(true);
            }
            else
            {
                objectsToToggle[i].SetActive(false);
            }
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedQ, TurnPrevPage);
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, TurnNextPage);
        }
    }
}