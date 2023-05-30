using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Core
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore;
        [SerializeField] private Button playButton, retryButton;
        [SerializeField] private RawImage gameOverImage;
        private GameManager _gameManager;
        private ScoreController _scoreController;
        
        [Inject]
        private void Construct(GameManager gameManager,ScoreController scoreController)
        {
            _gameManager = gameManager;
            _scoreController = scoreController;
        }

        private void Awake()
        {
            playButton.onClick.AddListener(_gameManager.StartGame);
            retryButton.onClick.AddListener(_gameManager.RestartGame);
            _gameManager.OnGameStartEvent += StartGame;
            _gameManager.OnGameOverEvent += GameOver;
            _scoreController.OnScoreChangedEvent += UpdateScore;
            ResetScore();
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
            gameOverImage.gameObject.SetActive(true);
        }

        private void UpdateScore(int currentScore)
        {
            score.text = currentScore.ToString();
            highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore")}";
        }

        private void ResetScore()
        {
            score.text = String.Empty;
            highScore.text = String.Empty;
        }

        private void OnDestroy()
        {
            _gameManager.OnGameStartEvent -= StartGame;
            _gameManager.OnGameOverEvent -= GameOver;
            _scoreController.OnScoreChangedEvent -= UpdateScore;
        }
    }
}