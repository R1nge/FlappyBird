using System;
using UnityEngine;

namespace Core
{
    public class ScoreController : MonoBehaviour
    {
        private int _currentScore;
        public event Action<int> OnScoreUpdated;

        private void Awake() => OnScoreUpdated += SaveHighScore;

        public void IncreaseScore(int amount)
        {
            _currentScore += amount;
            OnScoreUpdated?.Invoke(_currentScore);
        }

        private void SaveHighScore(int newScore)
        {
            var highScore = PlayerPrefs.GetInt("HighScore", 0);
            bool gotNewHighScore = newScore > highScore;

            if (!gotNewHighScore) return;
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
        }
    }
}