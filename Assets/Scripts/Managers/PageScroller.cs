using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
    //a este singleton le pones los gameobjectpadre que contienen todo lo de su pagina gg
    //por otra parte, la diea de cambiar de pagina es que isntancia una new hoja, espere a que gire, y luegpo spawnea los objetos

    public static PageScroller instance;

    [SerializeField]
    private GameObject[] objectsToToggle;

    [HideInInspector]
    public int activeIndex = 0; //currentpage = activeindex - 1

    public TriggerScript esferaPrev;
    public TriggerScript esferaNext;

    public GameObject hojaMaster;
    public GameObject hojaMasterRev;

    public bool isNext;

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
        EventManager.Subscribe(Evento.OnPageFinishTurning, SetActiveObject);
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
                isNext = true;
                SetOnPlayerChangePageTrigger();
                AudioManager.instance.PlayByName("PageTurn01");
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
                isNext = false;
                SetOnPlayerChangePageTrigger();
                AudioManager.instance.PlayByName("PageTurn02");
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

    private void SetOnPlayerChangePageTrigger()
    {
        LevelManager.instance.agency = false;  
        CreateHoja(isNext);
        CheckSpheres(activeIndex);
        //EventManager.Trigger(Evento.OnPlayerChangePage, activeIndex + 1);
    }

    void CreateHoja(bool isNext)
    {
        if (isNext)
        {
            //Hoja h = Instantiate(hoja, transform);
            //h.transform.position = hojaPosition;
            Instantiate(hojaMaster, transform);
        }
        else
        {
            //Hoja h = Instantiate(hojaRev, transform);
            //h.transform.position = hojaPosition;
            Instantiate(hojaMasterRev, transform);
        }
    }
    void SetActiveObject(params object[] parameter)
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
        EventManager.Trigger(Evento.OnPlayerChangePage, activeIndex + 1, isNext);
    } //este se dispara cuando la hoja termina de girar y avisa "che ya termine de girar" a traves el evento onpagefinishturnng

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedQ, TurnPrevPage);
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, TurnNextPage);
            EventManager.Unsubscribe(Evento.OnPageFinishTurning, SetActiveObject);

        }
    }
}