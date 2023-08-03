using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : MonoBehaviour
{
    //este script se encarga de cambiar las paginas y algunas cosas mas

    //cuando tocas E, instancia la hoja que debe girar, y dispara metodos
    //entre ellos, cerrar/abrir pubs, luego mover al player
    
    //tambien chequea cual zona de cambio de pagina deberia mostrarse

    public static PageScroller instance;

    [SerializeField]
    private GameObject[] objectsToToggle; //las 5 carpetas (buildingspagina1, 2, 3, 4 y 5)

    [HideInInspector]
    public int activeIndex = 0; //currentpage = activeindex - 1
    public int startingPage = 0;
    public TriggerScript esferaPrev; //la zona para volver a pag anterior
    public TriggerScript esferaNext; //la zona para ir a pag siguiente

    public GameObject hojaMaster; //el prefab de la hoja que va para adelante
    public GameObject hojaMasterRev; //idem para atras
    [SerializeField]
    float delayTime;
    [SerializeField]
    float popupDelayTime;
    [HideInInspector]
    public bool isNext;

    bool isTurning = false;


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

        //EventManager.Subscribe(Evento.OnPlayerPressedQ, TurnNextPage);
        EventManager.Subscribe(Evento.OnPlayerPressedE, TurnNextPage);
        EventManager.Subscribe(Evento.OnPageFinishTurning, FinishTurning);
        activeIndex = startingPage - 1;
        CheckSpheres(activeIndex);
    }

    void TurnNextPage(params object[] parameters)
    {
        if (esferaNext.triggerBool) //pregunta si el player esta encima del trigger
        {
            if (!isTurning)
            {
                if (activeIndex >= objectsToToggle.Length - 1)
                {
                    print("no hay mas paginas");
                }
                else
                {
                    activeIndex++;
                    isNext = true;
                    StartChangePage();
                    isTurning = true;
                }
            }
        }

        if (esferaPrev.triggerBool)
        {
            if (!isTurning)
            {
                if (activeIndex <= 0)
                {
                    print("no hay mas paginas");
                }
                else
                {
                    activeIndex--;
                    isNext = false;
                    StartChangePage();
                    isTurning = true;
                }
            }
        }
    }
    //void TurnPrevPage(params object[] parameters)
    //{
    //    if (esferaPrev.triggerBool)
    //    {
    //        if (!isTurning)
    //        {
    //            if (activeIndex <= 0)
    //            {
    //                print("no hay mas paginas");
    //            }
    //            else
    //            {
    //                activeIndex--;
    //                isNext = false;
    //                StartChangePage();
    //                isTurning = true;
    //            }
    //        }
    //    }
    //}
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
    void StartChangePage() //aca EMPIEZA a girar la pagina
    {
        CameraManager.instance.SetCamera(CameraMode.BookCenter);
        StartCoroutine(ChangePageCoroutine(delayTime));
        StartCoroutine(AbrirPUBsCoroutine(popupDelayTime));
    }
    public IEnumerator ChangePageCoroutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        if (isNext)
        {
            AudioManager.instance.PlayByName("PageTurn01", 0.9f);
        }
        else
        {
            AudioManager.instance.PlayByName("PageTurn02", 0.9f);
        }
        LevelManager.instance.inDialogue = true;  //freezeo a kami
        CreateHoja(isNext); //instancio la hoja que corresponda
        CheckSpheres(activeIndex); //chequeo si hay que poner/sacar zona
        PUBManager.instance.ClosePUBs();
    }
    public IEnumerator AbrirPUBsCoroutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        EventManager.Trigger(Evento.OnPlayerChangePage, activeIndex + 1, isNext);

        for (int i = 0; i < objectsToToggle.Length; i++) //este es el core, el q prende y apaga la carpeta de cada pagina
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
        PUBManager.instance.OpenPUBs();
    }
    void CreateHoja(bool isNext)
    {
        if (isNext)
        {
            Instantiate(hojaMaster, transform);
        }
        else
        {
            Instantiate(hojaMasterRev, transform);
        }
    }
    void FinishTurning(params object[] parameter) //esto recien se triggerea cuando TERMINA de cambiar la pagina
    {
        LevelManager.instance.inDialogue = false;
        isTurning = false;
        esferaNext.triggerBool = false;
        esferaPrev.triggerBool = false;
        CameraManager.instance.SetCamera(CameraMode.Normal);
    } //este se dispara cuando la hoja termina de girar y avisa "che ya termine de girar" a traves el evento onpagefinishturnng

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            //EventManager.Unsubscribe(Evento.OnPlayerPressedQ, TurnPrevPage);
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, TurnNextPage);
            EventManager.Unsubscribe(Evento.OnPageFinishTurning, FinishTurning);
        }
    }
}