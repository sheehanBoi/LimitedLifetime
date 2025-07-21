using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject winTextUI;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You Win! Game Over!");

            Time.timeScale = 0f;

            if (winTextUI != null) 
            {
                winTextUI.SetActive(true);
            }
        }
    }
}
