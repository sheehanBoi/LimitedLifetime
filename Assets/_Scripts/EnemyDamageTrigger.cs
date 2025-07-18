using UnityEngine;

public class EnemyDamageTrigger : MonoBehaviour
{
    public bool shouldDamage = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shouldDamage)
        {
            return;
        }

        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) 
            {
                enemy.TakeDamage(1);
                shouldDamage = false;
            }

            Debug.Log("Hit Enemy");
        }
        
    }
}
