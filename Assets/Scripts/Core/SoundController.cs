using UnityEngine;
using VContainer;

namespace Core
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField] private AudioSource scoreSound, gameOverSound;
        private GameManager _gameManager;
        private ScoreController _scoreController;

        [Inject]
        private void Inject(GameManager gameManager, ScoreController scoreController)
        {
            _gameManager = gameManager;
            _scoreController = scoreController;
        }

        private void Awake()
        {
            _gameManager.OnGameOverEvent += PlayGameOverSound;
            _scoreController.OnScoreChangedEvent += PlayScoreSound;
        }

        private void PlayScoreSound(int _) => scoreSound.Play(0);

        private void PlayGameOverSound() => gameOverSound.Play(0);

        private void OnDestroy()
        {
            _gameManager.OnGameOverEvent -= PlayGameOverSound;
            _scoreController.OnScoreChangedEvent -= PlayScoreSound;
        }
    }
}