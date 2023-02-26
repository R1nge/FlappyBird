using System;
using UnityEngine;

namespace Core
{
    public class ScoreController : MonoBehaviour
    {
        private int _currentScore;

        public event Action OnScoreChanged;
        public event Action<int> OnScoreChangedInt;

        private void Awake() => OnScoreChangedInt += SaveHighScore;

        public void IncreaseScore(int amount)
        {
            _currentScore += amount;
            OnScoreChangedInt?.Invoke(_currentScore);
            OnScoreChanged?.Invoke();
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