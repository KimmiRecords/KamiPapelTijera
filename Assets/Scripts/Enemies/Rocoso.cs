using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rocoso : Enemy
{
    //este script deberia estar en donde esta el animator, asi puedo llamar metodos de aca. unity, no lo entenderias.
    //esto deberia tener statemachine, asi ordeno bien cuando camina, ataca, etc. por ahora es que se acerca durante 2 seg y luego ataca.

    [SerializeField]
    Animator _anim;

    [SerializeField]
    SpriteRenderer _sr;

    bool wasAwoken;

    Player _player;

    private void Update()
    {
        if (_anim.GetBool("isWalk"))
        {
            Vector3 distance = _player.transform.position - transform.position;
            transform.position += distance.normalized * speed * Time.deltaTime;
        }
    }

    public void RocosoDespierta(Player player) //a ser disparada por el trigger solo la primera vez
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
        yield return new WaitForSeconds(3);
        RocosoAtaca();
    }

    public void RocosoAtaca()
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

    public void Headbutt() //esto se dispara en el momento correcto de la animacion de cabezazo
    {
        //crear hitbox
        //si esta toca un player, le hace daño
    }




}