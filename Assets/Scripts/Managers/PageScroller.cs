using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScroller : Singleton<PageScroller>
{
    //este script se encarga de cambiar las paginas y algunas cosas mas

    //cuando tocas E, instancia la hoja que debe girar, y dispara metodos
    //entre ellos, cerrar/abrir pubs, luego mover al player
    
    //tambien chequea cual zona de cambio de pagina deberia mostrarse
    [SerializeField] GameObject[] objectsToToggle; //las 5 carpetas (buildingspagina1, 2, 3, 4 y 5)

    [HideInInspector] public int activeIndex = 0; //currentpage = activeindex - 1
    public int startingPage = 0;
    public TriggerScript esferaPrev; //la zona para volver a pag anterior
    public TriggerScript esferaNext; //la zona para ir a pag siguiente

    public GameObject hojaMaster; //el prefab de la hoja que va para adelante
    public GameObject hojaMasterRev; //idem para atras
    [SerializeField] float delayTime;
    [SerializeField] float popupDelayTime;
    [HideInInspector] public bool isNext;

    bool isTurning = false;

    public GameObject glitterParent;
    ParticleSystem[] glitterSystems;

    protected override void Awake()
    {
        base.Awake();
        EventManager.Subscribe(Evento.OnPlayerPressedE, TriggerPageScroll);
        EventManager.Subscribe(Evento.OnPageFinishTurning, FinishTurning);
        activeIndex = startingPage - 1;
        CheckSpheres(activeIndex);
        GetAllParticleSystemsInChildren(glitterParent);
    }

    public void GetAllParticleSystemsInChildren(GameObject glitterParent)
    {
        glitterSystems = glitterParent.GetComponentsInChildren<ParticleSystem>();
    }
    void TriggerPageScroll(params object[] parameters)
    {
        if (esferaNext.triggerBool && !isTurning) //pregunta si el player esta encima del trigger
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

        if (esferaPrev.triggerBool && !isTurning)
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
    void StartChangePage() //aca EMPIEZA a girar la pagina
    {
        CameraManager.Instance.SetCamera(CameraMode.BookCenter);
        StartCoroutine(CerrarPUBsCoroutine(delayTime));
        StartCoroutine(AbrirPUBsCoroutine(popupDelayTime));
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
    public IEnumerator CerrarPUBsCoroutine(float delayTime)
    {
        //insta
        PlayGlitter();
        AudioManager.instance.PlayByName("MagicSuccess", 0.4f);
        StartCoroutine(PostProcessManager.Instance.LerpBloomIntensity());
        yield return new WaitForSeconds(delayTime);

        //despues de esperar un toque
        PlayPageSound();
        LevelManager.instance.inDialogue = true;  //freezeo a kami
        CreateHoja(isNext); //instancio la hoja que corresponda
        CheckSpheres(activeIndex); //chequeo si hay que poner/sacar zona
        PUBManager.Instance.ClosePUBs();
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
        PUBManager.Instance.OpenPUBs();
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
        CameraManager.Instance.SetCamera(CameraMode.Normal);
        //glitter.SetActive(false);

    } //este se dispara cuando la hoja termina de girar y avisa "che ya termine de girar" a traves el evento onpagefinishturnng
    private void PlayPageSound()
    {
        if (isNext)
        {
            AudioManager.instance.PlayByName("PageTurn01", 0.9f);
        }
        else
        {
            AudioManager.instance.PlayByName("PageTurn02", 0.9f);
        }
    }
    public void PlayGlitter()
    {
        foreach (ParticleSystem ps in glitterSystems)
        {
            ps.Play();
        }
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, TriggerPageScroll);
            EventManager.Unsubscribe(Evento.OnPageFinishTurning, FinishTurning);
        }
    }
}