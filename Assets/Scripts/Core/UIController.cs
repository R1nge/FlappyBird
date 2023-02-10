using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore;
        [SerializeField] private Button playButton, retryButton;
        [SerializeField] private RawImage gameOverImage;
        private ScoreController _scoreController;

        private void Awake()
        {
            GameManager.Instance.OnGameStartEvent += StartGame;
            GameManager.Instance.OnGameOverEvent += GameOver;

            gameOverImage.enabled = false;

            _scoreController = FindObjectOfType<ScoreController>();
            _scoreController.OnScoreUpdated += UpdateScore;

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

        private void OnDestroy() => _scoreController.OnScoreUpdated -= UpdateScore;
    }
}