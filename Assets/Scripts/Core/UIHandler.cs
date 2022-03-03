using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore;
        [SerializeField] private Button playButton, retryButton;
        [SerializeField] private RawImage gameOverImage;
        private GameManager _gameManager;
        private HighScoreSaver _highScoreSaver;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartEvent += StartGame;
            _gameManager.OnGameOverEvent += GameOver;

            gameOverImage.enabled = false;

            _highScoreSaver = FindObjectOfType<HighScoreSaver>();
            _highScoreSaver.OnScoreUpdated += UpdateScore;

            UpdateScore(0);
        }

        private void StartGame()
        {
            playButton.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
            highScore.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
        }

        private void GameOver()
        {
            highScore.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);

            gameOverImage.enabled = true;
        }

        private void UpdateScore(int currentScore)
        {
            score.text = currentScore.ToString();
            highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
        }

        private void OnDestroy()
        {
            _gameManager.OnGameStartEvent -= StartGame;
            _gameManager.OnGameOverEvent -= GameOver;
        }
    }
}