using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 2;

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
