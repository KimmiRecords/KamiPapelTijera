using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocoso : Enemy, IMojable
{
    //este script tiene que estar en donde esta el animator
    //asi las animaciones pueden llamar a metodos de este script.
    //unity, no lo entenderias.

    public Animator anim; //mi animator
    public RocosoHeadbuttHitBox _hitBox;
    public float attackRange = 11;
    public float disengageRange = 30;
    [SerializeField] GameObject _particulasSplash;

    [HideInInspector] public bool wasAwoken; //si el player ya se acerco y me despertó
    [HideInInspector] public bool startAnimationHasFinished = false; //si el player ya se acerco y me despertó
    [HideInInspector] public Vector3 target;
    [HideInInspector] public bool isHitting;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool deathAnimationEnded = false;

    Player _player;
    protected FiniteStateMachine _fsm;

    private void Start()
    {
        _fsm = new FiniteStateMachine();
        _fsm.AddState(State.RocosoSleep, new RocosoSleepState(_fsm, this));
        _fsm.AddState(State.RocosoStart, new RocosoStartState(_fsm, this));
        _fsm.AddState(State.RocosoWalk, new RocosoWalkState(_fsm, this));
        _fsm.AddState(State.RocosoAttack, new RocosoAttackState(_fsm, this));
        _fsm.AddState(State.RocosoDeath, new RocosoDeathState(_fsm, this));
        _fsm.ChangeState(State.RocosoSleep);

        _hitBox.headbuttDamage = _attackDamage;
    }

    private void Update()
    {
        _fsm.Update();

        if (_player != null)
        {
            target = _player.transform.position;
        }
    }

    public override void TakeDamage(float dmg)
    {
        _hp -= dmg;
        if (_hp <= 0)
        {
            StartCoroutine(MorirCoroutine());
        }
        StartCoroutine(EnrojecerSprite());
    }

    public void RocosoDespierta(Player player) //este metodo es disparado por el trigger, solo la primera vez
    {
        if (!wasAwoken)
        {
            _player = player;
            wasAwoken = true;
        }
    }

    public void RocosoCamina() //disparada por el final de la animacion de start
    {
        startAnimationHasFinished = true;
    }

    IEnumerator HeadbuttCoroutine() //esto se dispara en el momento correcto de la animacion de cabezazo
    {
        EnableHeadbuttHitbox();
        yield return new WaitForSeconds(0.1f);
        DisableHeadbuttHitbox();
    }
    public void EnableHeadbuttHitbox()
    {
        //Debug.Log("prendo el headbutt");
        _hitBox.gameObject.SetActive(true);
    }
    public void DisableHeadbuttHitbox()
    {
        //Debug.Log("apago el headbutt");
        _hitBox.gameObject.SetActive(false);
        isHitting = false;
    }

    public void GetWet() //esto se dispara cuando collisiona con el rio
    {
        //Debug.Log("rocoso se moja");

        _particulasSplash.SetActive(true);
        AudioManager.instance.PlayByName("BigWaterSplash");

        StartCoroutine(MorirCoroutine());
    }

    public void DeathAnimationEnd() //esto lo dispara el animator (especificamente, el final de clip de death)
    {
        //Debug.Log("termina el clip de muerte");
        deathAnimationEnded = true;
    }

    public IEnumerator MorirCoroutine() //la corrutina esta es solo para esperar a la anim antes de disparar Die()
    {
        Debug.Log("arranco corrutina de morir");
        isDead = true; //necesito un bool para que se haga el cambio de state. pero todavia no quiero morir posta
        
        //espero a que termine la animacion de muerte
        while (!deathAnimationEnded)
        {
            yield return null;
        }
        
        Die();
    }

    
}