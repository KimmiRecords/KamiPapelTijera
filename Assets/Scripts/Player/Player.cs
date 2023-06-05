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
    int _papel;
    bool _readyToAttack = true;
    bool isBarco = false;
    float originalJumpForce;
    OrigamiForm currentOrigamiStance;

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
            EventManager.Trigger(Evento.OnPlayerChangeVida, _hp, _maxHp);
        }
    }
    public int Papel
    {
        get
        {
            return _papel;
        }
        set
        {
            _papel = value;
            if (_papel < 0)
            {
                _papel = 0;
            }
            EventManager.Trigger(Evento.OnPlayerChangePapel, _papel);
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
        originalJumpForce = jumpForce;

        EventManager.Subscribe(Evento.OnOrigamiApplied, AddPaper);
        EventManager.Subscribe(Evento.OnCortableDropsPaper, AddPaper);

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
        if (!isBarco)
        {
            print("AAAA ME MOJO");
            _view.StartGetWetAnimation();
            PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
        }
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

    public void AddPaper(params object[] parameter)
    {
        //EndOrigamiStance(currentOrigamiStance); //termina la stance anterior

        //currentOrigamiStance = (OrigamiForm)parameter[0]; //nueva

        //switch (currentOrigamiStance)
        //{
        //    case OrigamiForm.Grulla:
        //        print("jump force duplicada");
        //        jumpForce *= 2;
        //        _renderer.material.color = Color.green;
        //        //Instantiate el cosito que quieras;
        //        break;

        //    case OrigamiForm.Barco:
        //        print("modo barco on");
        //        _renderer.material.color = Color.blue;
        //        isBarco = true;
        //        break;
        //}

        //param0 deberia ser el costo de papel. 
        Papel += (int)parameter[0];
    }

    //public void EndOrigamiStance(OrigamiForm origamiStance)
    //{
    //    //switch (currentOrigamiStance)
    //    //{
    //    //    case OrigamiForm.Grulla:
    //    //        print("jump force vuelve a original");
    //    //        jumpForce = originalJumpForce;
    //    //        break;

    //    //    case OrigamiForm.Barco:
    //    //        print("modo barco off");
    //    //        isBarco = false;
    //    //        break;
    //    //}
    //    //_renderer.material.color = originalColor;

    //}

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnOrigamiApplied, AddPaper);
            EventManager.Unsubscribe(Evento.OnCortableDropsPaper, AddPaper);

        }
    }
}
