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
    public CharacterController cc;
    public TijeraHitbox miTijeraHitbox;

    [SerializeField]
    Renderer _renderer;

    [HideInInspector]
    public bool isJump;
    PlayerModel _model;
    PlayerView _view;
    PlayerController _controller;
    float maxHp;

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


    void Start()
    {
        _model = new PlayerModel(this);
        _view = new PlayerView();
        _controller = new PlayerController(this);
        miTijeraHitbox.tijeraDamage = _attackDamage;
        maxHp = _hp;
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
    }

    public void OnPrimaryClick()
    {
        StartCoroutine(TijeraCoroutine());
        _view.StartTijeraAnimation();
    }

    IEnumerator TijeraCoroutine()
    {
        _model.EnableTijeraHitbox();
        yield return new WaitForSeconds(0.1f);
        _model.DisableTijeraHitbox();
    }
    public void GetWet()
    {
        print("AAAA ME MOJO");
        _view.StartGetWetAnimation();
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }

    public void GetGolpeado(float dmg)
    {
        print("me han golpeao");
        _view.StartGetWetAnimation();
        TakeDamage(dmg);
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        StartCoroutine(EnrojecerSprite());
    }

    public IEnumerator EnrojecerSprite()
    {
        //print("enrojeci el sprite");
        _renderer.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        _renderer.material.color = Color.white;
    }

    public override void Die()
    {
        print("player: me mori");
        _hp = maxHp;
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, PageScroller.instance.isNext); //spawnea al player en el inicio de la pagina actual
    }
}
