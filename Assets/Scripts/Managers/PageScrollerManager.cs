using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageScrollerManager : Singleton<PageScrollerManager>
{
    //este script se encarga de cambiar las paginas y algunas cosas mas

    //cuando tocas E, instancia la hoja que debe girar, y dispara metodos
    //entre ellos, cerrar/abrir pubs, luego mover al player
    
    //tambien chequea cual zona de cambio de pagina deberia mostrarse
    [SerializeField] GameObject[] pagesToToggle; //las 5 carpetas (buildingspagina1, 2, 3, 4 y 5)

    public int startingPage = 1;
    [HideInInspector] public int activePageIndex = 0; //activeIndex = startingPage - 1;
    public TriggerScript esferaPrev; //la zona para volver a pag anterior
    public TriggerScript esferaNext; //la zona para ir a pag siguiente

    public GameObject hojaMaster; //el prefab de la hoja que va para adelante
    public GameObject hojaMasterRev; //idem para atras
    [SerializeField] float delayTime;
    [SerializeField] float popupDelayTime;
    public bool _isNext = true;

    bool _isTurning = false;

    public GameObject glitterParent;
    ParticleSystem[] glitterSystems;

    GameObject hojaAux; //solo la guardo para luego poder destruirla


    protected override void Awake()
    {
        base.Awake();
        EventManager.Subscribe(Evento.OnPlayerPressedE, TriggerPageScroll);
        EventManager.Subscribe(Evento.OnPageFinishTurning, FinishTurning);
        activePageIndex = startingPage - 1;
        CheckSpheres(activePageIndex);
        GetAllParticleSystemsInChildren(glitterParent);
    }
    public void GetAllParticleSystemsInChildren(GameObject glitterParent)
    {
        glitterSystems = glitterParent.GetComponentsInChildren<ParticleSystem>();
    }


    public void TriggerPageScroll(params object[] parameters)
    {
        if (!OverlayManager.Instance.isLocked)
        {
            if (esferaNext.triggerBool && !_isTurning) //pregunta si el player esta encima del trigger
            {
                if (activePageIndex >= pagesToToggle.Length - 1)
                {
                    print("no hay mas paginas");
                }
                else
                {
                    ChangeToNextPage();
                }
            }

            if (esferaPrev.triggerBool && !_isTurning)
            {
                if (activePageIndex <= 0)
                {
                    print("no hay mas paginas");
                }
                else
                {
                    ChangeToPrevPage();
                }
            }
        }
    }

    private void ChangeToPrevPage()
    {
        activePageIndex--; //el paso de pagina posta, para atras
        _isNext = false; //isNext es una variable piola que mucha gente necesita
        StartChangePage();
        _isTurning = true;
        esferaPrev.triggerBool = false;
        EventManager.Trigger(Evento.OnPageTurned, activePageIndex);
    }

    private void ChangeToNextPage(/*bool isNext, bool isTurning, bool esferaTriggerBool*/)
    {
        activePageIndex++; //el paso de pagina posta
        _isNext = true; //isNext es una variable piola que mucha gente necesita
        StartChangePage();
        _isTurning = true;
        esferaNext.triggerBool = false;
    }

    void StartChangePage() //aca EMPIEZA a girar la pagina
    {
        CameraManager.Instance.SetCamera(CameraMode.BookCenter);
        StartCoroutine(CerrarPUBsCoroutine(delayTime));
        StartCoroutine(AbrirPUBsCoroutine(popupDelayTime));
    }
    public void CheckSpheres(int activePageIndex)
    {
        //este metodo chequea, segun la currentPage, que esferas deberian estar activas
        if (activePageIndex <= 0)
        {
            esferaPrev.OnExitBehaviour();
            esferaPrev.gameObject.SetActive(false);
        }
        else
        {
            esferaPrev.gameObject.SetActive(true);

        }

        if (activePageIndex >= pagesToToggle.Length - 1)
        {
            esferaNext.OnExitBehaviour();
            esferaNext.gameObject.SetActive(false);
        }
        else
        {
            esferaNext.gameObject.SetActive(true);
        }
    }
    public IEnumerator CerrarPUBsCoroutine(float delayTime) //cierro la pag actual
    {
        //insta (efectos y boludeces)
        PlayGlitter();
        AudioManager.instance.PlayByName("MagicSuccess", 0.42f, 0.01f);
        StartCoroutine(PostProcessManager.Instance.LerpBloomIntensity());
        yield return new WaitForSeconds(delayTime);

        //despues de esperar un toque
        PlayPageSound();
        LevelManager.Instance.inDialogue = true;  //freezeo a kami
        CreateHoja(_isNext); //instancio la hoja que corresponda
        CheckSpheres(activePageIndex); //chequeo si hay que poner/sacar zona
        PUBManager.Instance.ClosePUBs();
    }
    public IEnumerator AbrirPUBsCoroutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        EventManager.Trigger(Evento.OnPlayerChangePage, activePageIndex + 1, _isNext);

        for (int i = 0; i < pagesToToggle.Length; i++) //este es el core, el q prende y apaga la carpeta de cada pagina
        {
            if (i == activePageIndex)
            {
                pagesToToggle[i].SetActive(true);
            }
            else
            {
                pagesToToggle[i].SetActive(false);
            }
        }
        PUBManager.Instance.OpenPUBs();
    } //abro la nueva pag
    void CreateHoja(bool isNext)
    {
        if (isNext)
        {
            hojaAux = Instantiate(hojaMaster, transform);
        }
        else
        {
            hojaAux = Instantiate(hojaMasterRev, transform);
        }
    }
    void FinishTurning(params object[] parameter) //esto recien se triggerea cuando TERMINA de cambiar la pagina
    {
        LevelManager.Instance.inDialogue = false;
        _isTurning = false;
        CameraManager.Instance.SetCamera(CameraMode.Normal);
        Destroy(hojaAux);
    } //este se dispara cuando la hoja termina de girar y avisa "che ya termine de girar" a traves el evento onpagefinishturnng
    void PlayPageSound()
    {
        if (_isNext)
        {
            AudioManager.instance.PlayByName("PageTurn01", 0.9f, 0.03f);
        }
        else
        {
            AudioManager.instance.PlayByName("PageTurn02", 0.9f, 0.03f);
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
            //EventManager.Unsubscribe(Evento.OnPlayerPressedE, TriggerPageScroll);
            EventManager.Unsubscribe(Evento.OnPageFinishTurning, FinishTurning);
        }
    }
}