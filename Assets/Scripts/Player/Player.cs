using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IMojable, IGolpeable, ITransportable, ICurable
{

    //player esta partido en 4. aca solo pongo lo que quiero que pase. 
    //model se encarga de pensar, controller de recibir los controles, y view de animaciones, sonidos, particulas etc
    //aca contruyo a los 3, y les paso mi refe. ellos hablan conmigo, no entre ellos.
    //ademas, yo tengo start y update, ellos no.

    public float jumpForce = 50f;
    public float gravityValue; //gravedad extra para que quede linda la caida del salto
    public float weaponCooldown;
    public CharacterController cc;
    public Animator anim;
    [SerializeField]
    Renderer _renderer;
    public TijeraHitbox miTijeraHitbox;
    [SerializeField]
    float tijeraHitBoxDuration = 0.1f;

    
    Color originalColor;

    [HideInInspector]
    public bool isJumpButtonDown;

    PlayerModel _model;
    [HideInInspector]
    public PlayerView _view;
    PlayerController _controller;

    float _maxHp;
    bool _readyToAttack = true;
    public bool isAttacking = false;
    public bool hasTijera = false;

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

    void Awake()
    {
        _model = new PlayerModel(this);
        _view = new PlayerView(this);
        _controller = new PlayerController(this);
        miTijeraHitbox.tijeraDamage = _attackDamage;
        _maxHp = _hp;
        Vida = _maxHp;

        originalColor = _renderer.material.color;

        EventManager.Subscribe(Evento.OnOrigamiStart, StartOrigamiCast);
        EventManager.Subscribe(Evento.OnOrigamiEnd, EndOrigamiCast);
        EventManager.Subscribe(Evento.OnPlayerGetTijera, GetTijera);


        //EventManager.Subscribe(Evento.OnCortableDropsPaper, AddPaper);

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
        if (_readyToAttack && hasTijera) //readytoattack se pone false cuando estoy en cooldown
        {
            _view.StartTijeraAnimation();
            _readyToAttack = false;
        }
    }
    public void StartTijeraCoroutine() //este metodo es solo xq el estupido animator no sabe disparar corrutinas. unity "2021"
    {
        StartCoroutine(TijeraCoroutine());
    }
    public IEnumerator TijeraCoroutine() //prendo y apago rapidamente la hitbox para simular un ataque
    {
        _model.EnableTijeraHitbox();
        yield return new WaitForSeconds(tijeraHitBoxDuration);
        _model.DisableTijeraHitbox();

        yield return new WaitForSeconds(weaponCooldown); //los ataques tienen cooldown, asi que espero
        _readyToAttack = true;
    }
    public void GetWet()
    {
        print("AAAA ME MOJO");
        _view.StartGetWetAnimation();
        Die();
        //PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }
    public void GetGolpeado(float dmg)
    {
        //print("me han golpeao");
        _view.StartGetWetAnimation(); //es solo x el sonido
        TakeDamage(dmg);
    }
    public void Transport(Vector3 movement)
    {
        ///Debug.Log("player transport");
        _model.Transportar(movement);
    }
    public override void TakeDamage(float dmg)
    {
        Vida -= dmg;
        if (Vida <= 0)
        {
            Die();
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
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }
    public void GetCured(int curacion)
    {
        Vida += curacion;
    }
    public void GetTijera(params object[] parameters
        )
    {
        hasTijera = true;
        miTijeraHitbox.transform.parent.gameObject.SetActive(true);
    }
    public void StartOrigamiCast(params object[] parameters)
    {
        _view.StartCast();
    }
    public void EndOrigamiCast(params object[] parameters)
    {
        _view.EndCast();
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnOrigamiStart, StartOrigamiCast);
            EventManager.Unsubscribe(Evento.OnOrigamiEnd, EndOrigamiCast);
            EventManager.Unsubscribe(Evento.OnPlayerGetTijera, GetTijera);
        }
    }
}
