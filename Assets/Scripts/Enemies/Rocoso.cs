using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocoso : Enemy
{
    //este script tiene que estar en donde esta el animator
    //asi las animaciones pueden llamar a metodos de este script.
    //unity, no lo entenderias.
    
    //todavia esta en proceso. la idea es que el enemigo sea un statemachine
    //y hacer por separado los scripts de EnemySleepState, EnemyStartState, EnemyWalkState, EnemyPursuitState, etc
    //por ahora es que se acerca durante 2 seg y luego ataca.

    public Animator anim; //mi animator
    public SpriteRenderer _sr; //y mi sprite renderer. esto y el metodo EnrojecerSprite deberia estar separado, tipo creado como EnemyView o algo asi
    public RocosoHeadbuttHitBox _hitBox;

    [HideInInspector]
    public bool wasAwoken; //si el player ya se acerco y me despertó
    [HideInInspector]
    public bool startAnimationHasFinished = false; //si el player ya se acerco y me despertó
    [HideInInspector]
    public Vector3 target;
    [HideInInspector]
    public bool isHitting;

    Player _player;
    protected FiniteStateMachine fsm;



    private void Start()
    {
        fsm = new FiniteStateMachine();
        fsm.AddState(State.RocosoSleep, new RocosoSleepState(fsm, this));
        fsm.AddState(State.RocosoStart, new RocosoStartState(fsm, this));
        fsm.AddState(State.RocosoWalk, new RocosoWalkState(fsm, this));
        fsm.AddState(State.RocosoAttack, new RocosoAttackState(fsm, this));
        fsm.ChangeState(State.RocosoSleep);

        _hitBox.headbuttDamage = _attackDamage;
    }

    private void Update()
    {
        fsm.Update();

        if (_player != null)
        {
            target = _player.transform.position;
        }
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

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        StartCoroutine(EnrojecerSprite());
    }
    public IEnumerator EnrojecerSprite()
    {
        //print("enrojeci el sprite");
        _sr.material.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        _sr.material.color = Color.white;
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




}