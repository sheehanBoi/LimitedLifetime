using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float attackRange = 0.8f;
    public float moveSpeed = 2f;
    public float attackCooldown = 1.5f;
    public LayerMask playerLayer;

    private Transform player;
    private float lastAttackTime;
    

    void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);
        
        if (playerCollider != null)
        {
            player = playerCollider.transform;

            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if(distanceToPlayer > attackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            }
            else
            {
                if(Time.time >= lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                    lastAttackTime = Time.time;
                }
            }
        }

    }

    void AttackPlayer()
    {
        Debug.Log("Enemy Attacked!");
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        Debug.Log(playerHealth);

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1);
            Debug.Log(playerHealth.health);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
