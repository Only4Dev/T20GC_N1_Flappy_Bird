using UnityEngine;

public class WorldMove : MonoBehaviour
{

    [SerializeField] float worldSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * worldSpeed * Time.deltaTime;    
    }

    public void StartMoving()
    {
        enabled = true;
    }

    public void StopMoving()
    {
        enabled = false;
    }
}
