using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float obstacleSpawnTime;
    [SerializeField] float spawnWidth;

    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {  
            GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            Instantiate(obstacle, spawnPosition, Random.rotation, obstacleParent);
            yield return new WaitForSeconds(obstacleSpawnTime);
        }
    }
}
