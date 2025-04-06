using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime;

    AudioSource ads;

    bool gameOver;
    float timeLeft;

    //public bool GameOver { get { return gameOver; }}
    public bool GameOver => gameOver;

    void Start()
    {
        ads = GetComponent<AudioSource>();

        gameOver = false;
        timeLeft = startTime;
    }

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f; 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            return;
        }

        DecreaseTime();
    }

    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }

    void DecreaseTime()
    {
        if (gameOver) return;

        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0f)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;

        if (musicAudioSource != null)
        {
            musicAudioSource.Stop();  
        }

        ads.Stop();
        ads.PlayOneShot(gameOverSFX, 0.2f);
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
