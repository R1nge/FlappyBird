using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    private Transform _player;
    private PlayerMovement _playerMovement;
    private PlayerTilt _playerTilt;
    private SoundHandler _soundHandler;
    private UIHandler _uiHandler;
    private HighScoreSaver _highScoreSaver;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _player.GetComponent<Rigidbody2D>().isKinematic = true;

        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerTilt = FindObjectOfType<PlayerTilt>();
        _soundHandler = FindObjectOfType<SoundHandler>();
        _uiHandler = FindObjectOfType<UIHandler>();
        _highScoreSaver = FindObjectOfType<HighScoreSaver>();

        _playerTilt.enabled = false;
        _playerMovement.enabled = false;

        Time.timeScale = 1;
    }

    private void StartGame()
    {
        _uiHandler.StartGame();

        _player.GetComponent<Rigidbody2D>().isKinematic = false;

        _playerMovement.enabled = true;
        _playerTilt.enabled = true;

        ObstaclePool.Instance.SpawnFromPool("Obstacle", new Vector2(_player.position.x + 5, Random.Range(-2.27f, 2.48f)), Quaternion.identity);
    }

    public void GameOver()
    {
        _uiHandler.GameOver();
        _soundHandler.PlayGameOverSound();
        _highScoreSaver.SaveHighScore(_highScoreSaver.currentScore);
        Time.timeScale = 0;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}