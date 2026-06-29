using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Transform obstaclesParent;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float spawnInterval = 2f;

    float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer -= spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, new Vector3(transform.position.x, Random.Range(-2.5f, 2.5f), transform.position.z),Quaternion.identity, obstaclesParent);
    }

    public void StartSpawning()
    {
        enabled = true;
    }

    public void StopSpawning()
    {
        enabled = false;
    }
}
