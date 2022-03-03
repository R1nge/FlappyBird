using System;
using UnityEngine;

namespace Core
{
    public class HighScoreSaver : MonoBehaviour
    {
        [SerializeField] private int currentScore;
        public event Action<int> OnScoreUpdated;

        private void Awake() => OnScoreUpdated += SaveHighScore;

        public void IncreaseScore(int amount)
        {
            currentScore += amount;
            OnScoreUpdated?.Invoke(currentScore);
        }

        private void SaveHighScore(int newScore)
        {
            var highScore = PlayerPrefs.GetInt("HighScore", 0);
            bool gotNewHighScore = newScore > highScore;

            if (gotNewHighScore)
            {
                PlayerPrefs.SetInt("HighScore", newScore);
                PlayerPrefs.Save();
            }
        }

        private void OnDestroy() => OnScoreUpdated -= SaveHighScore;
    }
}