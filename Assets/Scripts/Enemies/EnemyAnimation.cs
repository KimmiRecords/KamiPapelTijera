using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation
{
    // el Enemy esta secretamente controlado por EnemyAnimation

    Enemy _thisEnemy;
    Animator _anim;

    public EnemyAnimation(Enemy enemy, Animator anim)
    {
        _anim = anim;
        _thisEnemy = enemy;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
