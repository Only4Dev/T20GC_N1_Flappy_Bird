using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameState
{
    Waiting,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] int highScore;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI highScoreText;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameOverUI;


    [SerializeField] WorldMove worldMove;
    [SerializeField] ObstacleSpawner obstacleSpawner;
    [SerializeField] Player player;
    [SerializeField] AudioManager audioManager;


    GameState currentState = GameState.Waiting;

    public GameState CurrentState
    {
        get { return currentState; }
    }

    private void Awake()
    {
        score = 0;
        UpdateScoreUI();
        currentState = GameState.Waiting;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
    }

    public void StartGame()
    {
        currentState = GameState.Playing;
        highScoreText.gameObject.SetActive(false);
        startUI.SetActive(false);
        player.StartPlaying();
        worldMove.StartMoving();
        obstacleSpawner.StartSpawning();
    }

    public void AddScore()
    {
        if (currentState == GameState.Playing)
        {
            audioManager.PlayScore();
            score++;
            UpdateScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"{score}";
    }

    private void UpdateHighScoreUI()
    {
        highScoreText.text = $"Best: {highScore}";
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        player.Die();
        worldMove.StopMoving();
        obstacleSpawner.StopSpawning();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreUI();
        }
        gameOverUI.SetActive(true);
        highScoreText.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
