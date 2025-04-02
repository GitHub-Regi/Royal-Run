using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] AudioClip checkpointSFX;

    [SerializeField] float checkpointTimeExtension;
    [SerializeField] float checkpointObstacleRateUp;
    
    AudioSource ads;
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;


    const string playerString = "Player";

    void Start()
    {
        ads = GetComponent<AudioSource>();
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            ads.PlayOneShot(checkpointSFX, 0.1f);
            gameManager.IncreaseTime(checkpointTimeExtension);
            obstacleSpawner.DecreaseObstacleSpawnTime(checkpointObstacleRateUp);
        }
    }
}
