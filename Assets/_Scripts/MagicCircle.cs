using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LifeTimer timer = FindObjectOfType<LifeTimer>();
            if(timer != null)
            {
                timer.ResetTimer();
                Debug.Log("Timer reset!");
            }

            gameObject.SetActive(false);
        }
    }
}
