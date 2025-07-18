using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    //public GameObject attackHitbox;
    public Transform attackOrigin;
    public Vector2 attackSize = new Vector2(1f, 1f);
    public LayerMask enemyLayer;

    float attackDuration = 0.2f;
    bool isAttacking = false;
    Vector2 lastMoveDir = Vector2.down;

    void Start()
    {
        //attackHitbox.SetActive(false);
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 inputDir = new Vector2(x, y);

        if(inputDir != Vector2.zero)
        {
            lastMoveDir = inputDir.normalized;
            
        }

        UpdateHitboxDirection();

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            
            StartCoroutine(PerformAttack());
        }
    }

    void UpdateHitboxDirection()
    {
        if(attackOrigin == null)
        {
            return;
        }

        Vector2 offset = lastMoveDir * 0.7f;
        attackOrigin.transform.localPosition = offset;
    }

    private System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true;

        Collider2D[] hits = Physics2D.OverlapBoxAll(attackOrigin.position, attackSize, 0f, enemyLayer);

        foreach(Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Attacking");
                enemy.TakeDamage(1);
            }
        }

        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackOrigin != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(attackOrigin.position, attackSize);
        }
    }

    /*
    private System.Collections.IEnumerator PerformAttack()
    {
        isAttacking = true;
        attackHitbox.SetActive(true);
        attackHitbox.GetComponent<EnemyDamageTrigger>().shouldDamage = true;

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.GetComponent<EnemyDamageTrigger>().shouldDamage = false;
        attackHitbox.SetActive(false);
        isAttacking = false;
    }
    */
}
