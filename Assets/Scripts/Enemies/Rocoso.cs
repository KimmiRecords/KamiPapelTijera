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

    [HideInInspector] public bool wasAwoken; //si el player ya se acerco y me despertó
    [HideInInspector] public bool startAnimationHasFinished = false; //si el player ya se acerco y me despertó
    [HideInInspector] public Vector3 target;
    [HideInInspector] public bool isHitting;

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

    public void GetWet()
    {
        Debug.Log("rocoso se moja");
        _sr.flipY = true;
        StartCoroutine(MojarseYMorirCoroutine());
    }

    public IEnumerator MojarseYMorirCoroutine()
    {
        Debug.Log("arranco corrutina de morir");
        float loQueDuraLaAnimDeMuerte = 2f;
        yield return new WaitForSeconds(loQueDuraLaAnimDeMuerte);
        _sr.flipY = false;
        Die();
    }
}