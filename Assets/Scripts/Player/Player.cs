using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IMojable, IGolpeable
{
    //player esta partido en 4. aca solo pongo lo que quiero que pase. 
    //model se encarga de pensar, controller de recibir los controles, y view de animaciones, sonidos, particulas etc
    //aca contruyo a los 3, y les paso mi refe. ellos hablan conmigo, no entre ellos.
    //ademas, yo tengo start y update, ellos no.

    public float jumpForce = 50f;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto
    public float weaponCooldown;
    public CharacterController cc;
    public TijeraHitbox miTijeraHitbox;
    public Animator anim;

    [SerializeField]
    Renderer _renderer;
    Color originalColor;

    [HideInInspector]
    public bool isJump;

    PlayerModel _model;
    public PlayerView _view;
    PlayerController _controller;
    float _maxHp;
    bool _readyToAttack = true;

    public float Speed 
    {
        get
        {
            return _speed;
        }
        set 
        {
            _speed = value;
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
    }
    private void Update()
    {
        if (LevelManager.instance.agency)
        {
            _controller.CheckControls();
        }

        if (_controller.hor != 0 || _controller.ver != 0)
        {
            EventManager.Trigger(Evento.OnPlayerMove, _controller.hor, _controller.ver);
        }

        _model.NewMove(_controller.hor, _controller.ver); //todo el tiempo, aunque no me mueva, pues caidas y bla
        _view.CheckMagnitude(_controller.hor, _controller.ver);
    }
    public void OnPrimaryClick()
    {
        if (_readyToAttack)
        {
            StartCoroutine(TijeraCoroutine());
            _view.StartTijeraAnimation();
            _readyToAttack = false;
        }
    }
    IEnumerator TijeraCoroutine()
    {

        _model.EnableTijeraHitbox();
        yield return new WaitForSeconds(0.1f);
        _model.DisableTijeraHitbox();

        yield return new WaitForSeconds(weaponCooldown);
        _readyToAttack = true;
    }
    public void GetWet()
    {
        print("AAAA ME MOJO");
        _view.StartGetWetAnimation();
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }
    public void GetGolpeado(float dmg)
    {
        //print("me han golpeao");
        _view.StartGetWetAnimation(); //es solo x el sonido
        TakeDamage(dmg);
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
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }
}
