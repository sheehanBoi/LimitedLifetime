using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public LifeTimer timer;
    private bool playerInside = false;

    private void Start()
    {
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           playerInside = true;
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    private void Update()
    {
        if(playerInside && timer != null)
        {
            timer.ResetTimer();
        }
    }
}
