using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IMojable, IGolpeable, ICurable
{

    //player esta partido en 4. aca solo pongo lo que quiero que pase. 
    //model se encarga de pensar, controller de recibir los controles, y view de animaciones, sonidos, particulas etc
    //aca contruyo a los 3, y les paso mi refe. ellos hablan conmigo, no entre ellos.
    //ademas, yo tengo start y update, ellos no.

    [Header("Stats")]
    public bool hasTijera = false;
    public bool hasTijeraMejorada = false;
    public bool hasSprintBoots = false;
    public bool hasWaterBoots = false;

    public float weaponCooldown;
    [SerializeField] float tijeraHitBoxDuration = 0.1f;
    public float jumpForce = 50f;
    public float gravityValue; //gravedad extra para que quede linda la caida del salto
    public float sprintingSpeedModifier = 1.5f;

    [Header("Componentes")]
    public CharacterController cc;
    public Animator anim;
    public TijeraHitbox miTijeraHitbox;
    [SerializeField] Renderer _renderer;
    [SerializeField] GameObject myPaperPlaneHat;
    [SerializeField] ParticleSystem sprintParticles;
    [SerializeField] TijeraManager tijeraManager;

    [Header("Planeo")]
    public float augmentedJumpForce = 20f;
    public int augmentedJumpsMax = 3;
    public float planeoImpulse = 2;
    public float planeoDuration = 1;
    public float planeoDelayTime = 1;

    //originals
    Color originalColor;
    float originalJumpForce;
    float _maxHp;
    float originalMaxSpeed;

    //auxiliars
    bool _readyToAttack = true;
    bool isDrowning = false;
    [HideInInspector] public bool isJumpButtonDown;
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isPaperPlaneHat = false; //pph es paper plane hat
    [HideInInspector] public bool isSprinting; //cuando tocas shift
    [HideInInspector] public int augmentedJumpsLeft;
    [HideInInspector] public Vector3 lastDirection;

    //MVC
    PlayerModel _model;
    [HideInInspector] public PlayerView _view;
    PlayerController _controller;

    //Properties
    public float Speed
    {
        get
        {
            return _maxSpeed;
        }
        set
        {
            _maxSpeed = value;
        }
    }
    public float Vida
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if (_hp > _maxHp)
            {
                _hp = _maxHp;
            }

            if (_hp < 0)
            {
                _hp = 0;
            }
            EventManager.Trigger(Evento.OnPlayerChangeVida, _hp, _maxHp);
        }
    }
    public bool IsSprinting
    {
        get
        {
            return isSprinting;
        }
        set
        {
            isSprinting = value;
            if (isSprinting && hasSprintBoots)
            {
                //Debug.Log("voy rapidin");
                Speed *= sprintingSpeedModifier;
                sprintParticles.gameObject.SetActive(true);
            }
            else
            {
                //Debug.Log("voy normal");
                Speed = originalMaxSpeed;
                sprintParticles.gameObject.SetActive(false);
            }
        }
    }


    void Awake()
    {
        _model = new PlayerModel(this);
        _view = new PlayerView(this);
        _controller = new PlayerController(this);

        EventManager.Subscribe(Evento.OnOrigamiStart, StartOrigamiCast);
        EventManager.Subscribe(Evento.OnOrigamiEnd, EndOrigamiCast);
        EventManager.Subscribe(Evento.OnPlayerGetTijera, GetTijera);
        EventManager.Subscribe(Evento.OnOrigamiGivePaperPlaneHat, GetPaperPlaneHat);
    }

    private void Start()
    {
        _maxHp = _hp;
        Vida = _maxHp;
        originalColor = _renderer.material.color;
        augmentedJumpsLeft = augmentedJumpsMax;
        originalJumpForce = jumpForce;
        originalMaxSpeed = _maxSpeed;
    }


    private void Update()
    {
        //todo el tiempo chequeo los controles. eso seguro.
        _controller.CheckControls();

        if (_controller.hor != 0 || _controller.ver != 0) //si estoy tocando cualquier WASD, triggerea evento
        {
            EventManager.Trigger(Evento.OnPlayerMove, _controller.hor, _controller.ver);
        }

        _model.NewMove(_controller.hor, _controller.ver); //de todos modos el model hace lo suyo. aunque no me mueva, pues caidas y bla
        _view.CheckMagnitude(_controller.hor, _controller.ver); //el view tambien necesita enterarse para donde me muevo
    }
    public void OnPrimaryClick()
    {
        if (_readyToAttack && hasTijera && !anim.GetBool("isCasting")) //readytoattack se pone false cuando estoy en cooldown
        {
            _readyToAttack = false;
            isAttacking = true;
            _view.StartAttack();
        }
    }
    public void StartTijeraCoroutine() //este metodo es solo xq el estupido animator no sabe disparar corrutinas. unity "2021"
    {
        StartCoroutine(TijeraCoroutine());
    }
    public IEnumerator TijeraCoroutine() //prendo y apago rapidamente la hitbox en el momento justo para simular un ataque
    {
        _model.EnableTijeraHitbox();
        yield return new WaitForSeconds(tijeraHitBoxDuration);
        _model.DisableTijeraHitbox();

        yield return new WaitForSeconds(weaponCooldown); //los ataques tienen cooldown, asi que espero
        _readyToAttack = true;
        isAttacking = false;
        _view.EndAttack();

    }
    public void GetWet(float wetDamage)
    {
        if (!hasWaterBoots)
        {
            //print("AAAA ME MOJO");
            _view.StartGetWetAnimation();
            //Die();
            isDrowning = true;
            StartCoroutine(DrowningCoroutine(wetDamage));
        }
    }
    public void StopGettingWet()
    {
        isDrowning = false;
    }
    public IEnumerator DrowningCoroutine(float wetDamage)
    {
        while (isDrowning)
        {
            TakeDamage(wetDamage);
            yield return new WaitForSeconds(0.8f);
        }
    }
    public void GetGolpeado(float dmg)
    {
        //print("me han golpeao");
        _view.StartGetGolpeadoAnimation(); //es solo x el sonido por ahora
        TakeDamage(dmg);
    }
    public override void TakeDamage(float dmg)
    {
        Vida -= dmg;
        if (Vida <= 0)
        {
            Die();
            isDrowning = false;
        }
        StartCoroutine(EnrojecerSprite());
    }
    public IEnumerator EnrojecerSprite()
    {
        //print("enrojeci el sprite");
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        _renderer.material.color = originalColor;
    }
    public override void Die()
    {
        print("player: me mori");
        Vida = _maxHp;
        EventManager.Trigger(Evento.OnPlayerDie);
        PlayerPageSpawnManager.Instance.RespawnPlayer(/*PageScroller.Instance.activeIndex + 1, PageScroller.Instance.isNext*/); //spawnea al player en el inicio de la pagina actual
    }
    public void GetCured(int curacion)
    {
        Vida += curacion;
    }
    public void GetTijera(params object[] parameters)
    {
        hasTijera = true;
        tijeraManager.SetTijera();
    }
    public void GetTijeraMejorada()
    {
        Debug.Log("player - get tijera mejorada");
        hasTijeraMejorada = true;
        tijeraManager.SetTijeraMejorada();
        miTijeraHitbox = tijeraManager.tijeraMejoradaHitbox;
    }
    public void StartOrigamiCast(params object[] parameters)
    {
        _view.StartCast();
    }
    public void EndOrigamiCast(params object[] parameters)
    {
        _view.EndCast();
    }
    public void GetPaperPlaneHat(params object[] parameters)
    {
        isPaperPlaneHat = true;
        jumpForce = augmentedJumpForce;
        augmentedJumpsLeft = augmentedJumpsMax;
        myPaperPlaneHat.SetActive(true);
        AudioManager.instance.PlayByName("ShipSpawn", 2f);

    }
    public void DestroyPaperPlaneHat(params object[] parameters)
    {
        isPaperPlaneHat = false;
        jumpForce = originalJumpForce;
        //sfx de hacer bollo y destruir
        myPaperPlaneHat.SetActive(false);
    }
    public void AddPlaning()
    {
        //print("AddPlaning: dalee");
        StartCoroutine(_model.AddExtraForwardForce(planeoDelayTime, planeoDuration));
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnOrigamiStart, StartOrigamiCast);
            EventManager.Unsubscribe(Evento.OnOrigamiEnd, EndOrigamiCast);
            EventManager.Unsubscribe(Evento.OnPlayerGetTijera, GetTijera);
            EventManager.Unsubscribe(Evento.OnOrigamiGivePaperPlaneHat, GetPaperPlaneHat);
        }
    }

    
}
