using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    //public GameObject attackHitbox;
    public Transform attackOrigin;
    public Vector2 attackSize = new Vector2(1f, 1f);
    public LayerMask enemyLayer;
    private Animator animator;

    float attackDuration = 0.2f;
    bool isAttacking = false;
    Vector2 lastMoveDir = Vector2.down;

    void Start()
    {
        //attackHitbox.SetActive(false);
        animator = GetComponent<Animator>();
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

        animator.SetFloat("LastMoveX", lastMoveDir.x);
        animator.SetFloat("LastMoveY", lastMoveDir.y);
        animator.SetBool("IsAttacking", true);
        Debug.Log("Attacking");
        //animator.SetTrigger("Attack");

        Collider2D[] hits = Physics2D.OverlapBoxAll(attackOrigin.position, attackSize, 0f, enemyLayer);

        foreach(Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Hit Enemy");
                enemy.TakeDamage(1);
            }
        }

        yield return new WaitForSeconds(attackDuration);
        animator.SetBool("IsAttacking", false);
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
