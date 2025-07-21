using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;
    public Slider healthSlider;

    private void Start()
    {
        if(healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(healthSlider != null)
        {
            healthSlider.value = health;
        }

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
