using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI score, highScore;
    public Button playButton, retryButton;
    private SpriteRenderer _gameOver;
    private Transform _player;
    private SoundHandler _soundHandler;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _gameOver = GameObject.Find("GameOver").GetComponent<SpriteRenderer>();
        _soundHandler = FindObjectOfType<SoundHandler>();

        _player.GetComponent<PlayerMovement>().enabled = false;
        _player.GetComponent<PlayerTilt>().enabled = false;
        _player.GetComponent<Rigidbody2D>().isKinematic = true;

        _gameOver.enabled = false;

        UpdateScore(0);

        Time.timeScale = 1;
    }

    public void Play()
    {
        playButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        score.gameObject.SetActive(true);

        _player.GetComponent<PlayerMovement>().enabled = true;
        _player.GetComponent<PlayerTilt>().enabled = true;
        _player.GetComponent<Rigidbody2D>().isKinematic = false;

        ObstaclePool.Instance.SpawnFromPool("Obstacle", new Vector2(_player.position.x + 5, Random.Range(-2.27f, 2.48f)), Quaternion.identity);
    }

    public void GameOver()
    {
        highScore.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        _gameOver.enabled = true;

        Time.timeScale = 0;

        _soundHandler.PlayGameOverSound();
    }

    public void UpdateScore(int currentScore)
    {
        score.text = currentScore.ToString();
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}