using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
    //a este singleton le pones los gameobjectpadre que contienen todo lo de su pagina gg

    public static PageScroller instance;

    [SerializeField]
    private GameObject[] objectsToToggle;
    int activeIndex = 0;

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

        CheckSpheres(activeIndex);
    }

    void TurnNextPage(params object[] parameters)
    {
        if (esferaNext.triggerBool) //pregunta si el player esta encima del trigger
        {
            if (activeIndex >= objectsToToggle.Length - 1)
            {
                print("no hay mas paginas");
            }
            else
            {
                activeIndex++;
                SetActiveObject();
                CheckSpheres(activeIndex);
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
                CheckSpheres(activeIndex);
            }
        }
    }

    public void CheckSpheres(int currentPage)
    {
        //este metodo chequea, segun la currentPage, que esferas deberian estar activas
        if (currentPage <= 0)
        {
            esferaPrev.OnExitBehaviour();
            esferaPrev.gameObject.SetActive(false);
        }
        else
        {
            esferaPrev.gameObject.SetActive(true);

        }

        if (currentPage >= objectsToToggle.Length - 1)
        {
            esferaNext.OnExitBehaviour();
            esferaNext.gameObject.SetActive(false);
        }
        else
        {
            esferaNext.gameObject.SetActive(true);
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

        EventManager.Trigger(Evento.OnPlayerChangePage, activeIndex + 1);
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