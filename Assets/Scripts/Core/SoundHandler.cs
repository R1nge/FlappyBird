using UnityEngine;

namespace Core
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource scoreSound, gameOverSound;
        private GameManager _gameManager;
        private HighScoreSaver _highScoreSaver;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameOverEvent += PlayGameOverSound;

            _highScoreSaver = FindObjectOfType<HighScoreSaver>();
            _highScoreSaver.OnScoreUpdated += PlayScoreSound;
        }

        private void PlayScoreSound(int i) => scoreSound.Play(0);

        private void PlayGameOverSound() => gameOverSound.Play(0);

        private void OnDestroy()
        {
            _gameManager.OnGameOverEvent -= PlayGameOverSound;
            _highScoreSaver.OnScoreUpdated -= PlayScoreSound;
        }
    }
}