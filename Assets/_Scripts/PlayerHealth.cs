using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 7;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You Died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Destroy(gameObject);

    }
}
