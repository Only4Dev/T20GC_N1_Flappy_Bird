using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
