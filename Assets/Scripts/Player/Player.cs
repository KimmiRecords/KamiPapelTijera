using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMojable
{
    //player esta partido en 4. aca solo pongo lo que quiero que pase. 
    //model se encarga de pensar, controller de recibir los controles, y view de animaciones, sonidos, particulas etc
    //aca contruyo a los 3, y les paso mi refe. ellos hablan conmigo, no entre ellos.
    //ademas, yo tengo start y update, ellos no.

    public float walkingSpeed = 5f;
    public float jumpForce = 50f;
    public float gravityValue;          //gravedad extra para que quede linda la caida del salto
    public float tijeraDamage;

    public CharacterController cc;

    [HideInInspector]
    public bool isJump;

    PlayerModel _model;
    PlayerController _controller;

    public TijeraHitbox miTijeraHitbox;




    void Start()
    {
        _model = new PlayerModel(this);
        _controller = new PlayerController(this);

        miTijeraHitbox.tijeraDamage = tijeraDamage;
    }

    private void Update()
    {
        if (LevelManager.instance.agency)
        {
            _controller.CheckControls();
        }

        if (_controller.hor != 0 || _controller.ver != 0)
        {
            //print(_controller.hor + "//" + _controller.ver);
            EventManager.Trigger(Evento.OnPlayerMove, _controller.hor, _controller.ver);
        }

        _model.NewMove(_controller.hor, _controller.ver); //todo el tiempo, aunque no me mueva, pues caidas y bla
    }

    public void OnPrimaryClick()
    {
        //print("ataque con tijera");
        //_view.startTijeraAnimation;
        StartCoroutine(TijeraCoroutine());
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
        PlayerPageSpawnManager.instance.PlacePlayer(PageScroller.instance.activeIndex + 1, true); //spawnea al player en el inicio de la pagina actual
    }
}
