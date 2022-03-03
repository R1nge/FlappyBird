using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnGameStartEvent;
        public event Action OnGameOverEvent;

        private void Awake() => SetTimeScale(1);

        private void StartGame() => OnGameStartEvent?.Invoke();

        public void GameOver()
        {
            OnGameOverEvent?.Invoke();
            SetTimeScale(0);
        }

        private void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void SetTimeScale(int value) => Time.timeScale = value;
    }
}