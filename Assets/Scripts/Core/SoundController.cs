using UnityEngine;

namespace Core
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource scoreSound, gameOverSound;
        private ScoreController _scoreController;

        private void Awake()
        {
            GameManager.Instance.OnGameOverEvent += PlayGameOverSound;
            _scoreController = FindObjectOfType<ScoreController>();
            _scoreController.OnScoreUpdated += delegate { PlayScoreSound(); };
        }

        private void PlayScoreSound() => scoreSound.Play(0);

        private void PlayGameOverSound() => gameOverSound.Play(0);
    }
}