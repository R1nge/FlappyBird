using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Core
{
    public class GameManager : IStartable
    {
        private bool _hasGameStarted, _hasGameEnded;
        public event Action OnGameStartEvent;
        public event Action OnGameOverEvent;
        
        public void Start() => SetTimeScale(1);

        public void StartGame()
        {
            OnGameStartEvent?.Invoke();
            _hasGameStarted = true;
            _hasGameEnded = false;
        }

        public void GameOver()
        {
            OnGameOverEvent?.Invoke();
            _hasGameEnded = true;
            SetTimeScale(0);
        }

        public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public bool HasGameStarted() => _hasGameStarted;

        public bool HasGameEnded() => _hasGameEnded;

        private void SetTimeScale(int value) => Time.timeScale = value;
    }
}