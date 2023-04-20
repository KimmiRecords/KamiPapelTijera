using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackDamage;

    public Entity SetHP(float desiredHp)
    {
        hp = desiredHp;
        return this;
    }
    public Entity SetSpeed(float desiredSpeed)
    {
        speed = desiredSpeed;
        return this;
    }
    public Entity SetAttackDamage(float desiredAtkDmg)
    {
        attackDamage = desiredAtkDmg;
        return this;
    }

    public virtual void TakeDamage(float dmg)
    {
        print("entity: recibi " + dmg + " damage");
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    
    public virtual void Die()
    {
        print("entity: me mori");
        Destroy(this.gameObject);
    }

}
