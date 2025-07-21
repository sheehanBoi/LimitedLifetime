using UnityEngine;

public class Enemy : MonoBehaviour
{
    float health = 2;
    private bool isDying = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(health <= 0 && !isDying)
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
        isDying = true;
        animator.SetTrigger("Death");

        StartCoroutine(DelayedDestroy());
        //Destroy(gameObject);
    }

    System.Collections.IEnumerator DelayedDestroy()
    {
        float deathAnimLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(deathAnimLength);
        Destroy(gameObject);
    }
}
