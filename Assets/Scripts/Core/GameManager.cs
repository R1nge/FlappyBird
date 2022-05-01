using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
 
                return _instance;
            }
            private set => _instance = value;
        }
        private static GameManager _instance;
        public event Action OnGameStartEvent;
        public event Action OnGameOverEvent;

        private void Awake() => SetTimeScale(1);

        public void StartGame() => OnGameStartEvent?.Invoke();

        public void GameOver()
        {
            OnGameOverEvent?.Invoke();
            SetTimeScale(0);
        }

        public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        private void SetTimeScale(int value) => Time.timeScale = value;
    }
}