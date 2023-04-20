using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float hp;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float attackDamage;

    public Enemy SetHP(float desiredHp)
    {
        hp = desiredHp;
        return this;
    }
    public Enemy SetSpeed(float desiredSpeed)
    {
        speed = desiredSpeed;
        return this;
    }
    public Enemy SetAttackDamage(float desiredAtkDmg)
    {
        attackDamage = desiredAtkDmg;
        return this;
    }

    public virtual void TakeDamage(float dmg)
    {
        print("enemy: recibi " + dmg + " damage");

        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        print("enemy: me mori");
        //EnemySpawner.instance.AddDeadEnemy();
        Destroy(this.gameObject);
    }

    
}