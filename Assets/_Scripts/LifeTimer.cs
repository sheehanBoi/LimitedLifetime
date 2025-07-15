using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeTimer : MonoBehaviour
{
    public float maxTime = 10f;
    public float currentTime;
    public Slider timerSlider;

    void Start()
    {
        ResetTimer();    
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if(timerSlider != null)
        {
            timerSlider.value = currentTime / maxTime;
        }

        if(currentTime <= 0f)
        {
            Die();
        }
    }

    public void ResetTimer()
    {
        currentTime = maxTime;
    }

    void Die()
    {
        Debug.Log("You Died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
