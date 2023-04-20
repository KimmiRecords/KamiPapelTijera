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

    [SerializeField]
    Animator _anim; //mi animator

    [SerializeField]
    SpriteRenderer _sr; //y mi sprite renderer. esto y el metodo EnrojecerSprite deberia estar separado, tipo creado como EnemyView o algo asi

    [SerializeField]
    RocosoHeadbuttHitBox _hitBox;

    bool wasAwoken; //si el player ya se acerco y me despertó
    Player _player;

    private void Start()
    {
        _hitBox.headbuttDamage = attackDamage;
    }

    private void Update()
    {
        if (_anim.GetBool("isWalk")) //todo el tiempo pregunto si estoy caminando
        {
            Vector3 distance = _player.transform.position - transform.position; //calculo pa'donde
            transform.position += distance.normalized * speed * Time.deltaTime; //voy pa'lla
        }
    }

    public void RocosoDespierta(Player player) //este metodo es disparado por el trigger, solo la primera vez
    {
        if (!wasAwoken)
        {
            //print("el rocoso despierta");
            _player = player;
            _anim.SetBool("isStart", true);
            wasAwoken = true;
        }
    }
    public void RocosoCamina() //disparada por el final de la animacion de start
    {
        //print("el rocoso empieza a caminar");
        _anim.SetBool("isWalk", true);
        StartCoroutine(RocosoCaminaCorrutina());
    }
    IEnumerator RocosoCaminaCorrutina()
    {
        //print("espero unos segundos caminando...");
        yield return new WaitForSeconds(2);
        RocosoComienzaAtaque();
    }
    public void RocosoComienzaAtaque()
    {
        //print("el rocoso ataca");
        _anim.SetBool("isWalk", false);
        _anim.SetBool("isAttack", true);
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
    }




}