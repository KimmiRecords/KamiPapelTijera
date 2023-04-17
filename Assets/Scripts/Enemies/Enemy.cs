using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour, ICortable
{
    [Tooltip("The health points of the enemy.")]
    public float hp = 100f;
    [Tooltip("The movement speed of the enemy.")]
    public float speed = 10f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // Implement movement logic here

        //idle hasta que el player los triggeree
        //normalmente se triggerean de una cuando cambias la pagina
    }

    [Tooltip("The damage amount dealt by the enemy's attack.")]
    public float attackDamage = 20f;
    [Tooltip("The duration of the attack animation.")]
    public float attackAnimationDuration = 1f;

    public void Attack()
    {
        // Implement attack logic here
        //preparan, muestran hitbox, pegan. luego recovery.
    }

    public void TakeDamage(float dmg)
    {
        print("enemy: recibi " + dmg + " damage");

        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("enemy: me mori");
        EnemySpawner.instance.AddDeadEnemy();
        Destroy(this.gameObject);
    }

    public void GetCut(float dmg)
    {
        print("enemy: me cortaron");
        AudioManager.instance.PlayByName("ShipCrash");

        TakeDamage(dmg);
    }
}