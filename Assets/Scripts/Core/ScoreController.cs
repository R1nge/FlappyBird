using System;
using UnityEngine;

namespace Core
{
    public class ScoreController
    {
        private int _currentScore;

        public event Action<int> OnScoreChangedEvent;

        public void IncreaseScore(int amount)
        {
            _currentScore += amount;
            OnScoreChangedEvent?.Invoke(_currentScore);
            TrySaveHighScore(_currentScore);
        }

        private void TrySaveHighScore(int newScore)
        {
            var highScore = PlayerPrefs.GetInt("HighScore", 0);
            bool gotNewHighScore = newScore > highScore;

            if (!gotNewHighScore) return;
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
        }
    }
}