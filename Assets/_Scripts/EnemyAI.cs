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
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer)
    }
}
