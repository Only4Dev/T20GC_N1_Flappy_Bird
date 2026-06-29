using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddScore();
        }
    }
}
