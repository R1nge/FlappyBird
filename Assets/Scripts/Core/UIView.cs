using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class UIView
    {
        private readonly TextMeshProUGUI _score, _highScore;
        private readonly Button _playButton, _retryButton;
        private readonly RawImage _gameOverImage;

        public UIView(TextMeshProUGUI score, TextMeshProUGUI highScore, Button playButton, Button retryButton, RawImage gameOverImage)
        {
            _score = score;
            _highScore = highScore;
            _playButton = playButton;
            _retryButton = retryButton;
            _gameOverImage = gameOverImage;
        }

        public Button GetPlayButton() => _playButton;
        public Button GetRetryButton() => _retryButton;

        public void OnGameStarted()
        {
            _playButton.gameObject.SetActive(false);
            _retryButton.gameObject.SetActive(false);
            _highScore.gameObject.SetActive(false);
            _score.gameObject.SetActive(true);
        }

        public void OnGameOver()
        {
            _highScore.gameObject.SetActive(true);
            _retryButton.gameObject.SetActive(true);
            _gameOverImage.gameObject.SetActive(true);
        }

        public void UpdateScore(int currentScore)
        {
            _score.text = currentScore.ToString();
            _highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore")}";
        }

        public void ResetScore()
        {
            _score.text = String.Empty;
            _highScore.text = String.Empty;
        }
    }
}