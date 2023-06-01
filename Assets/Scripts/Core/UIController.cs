using UnityEngine;
using VContainer;

namespace Core
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIModel uiModel;
        private UIView _uiView;
        private GameManager _gameManager;
        private ScoreController _scoreController;

        [Inject]
        private void Construct(GameManager gameManager, ScoreController scoreController)
        {
            _gameManager = gameManager;
            _scoreController = scoreController;
        }

        private void Awake()
        {
            _uiView = new(uiModel.score, uiModel.highScore, uiModel.playButton, uiModel.retryButton, uiModel.gameOverImage);
            _gameManager.OnGameStartEvent += OnGameStarted;
            _gameManager.OnGameOverEvent += OnGameOver;
            _scoreController.OnScoreChangedEvent += OnScoreChanged;
        }

        private void Start()
        {
            _uiView.ResetScore();
            _uiView.GetPlayButton().onClick.AddListener(_gameManager.StartGame);
            _uiView.GetRetryButton().onClick.AddListener(_gameManager.RestartGame);
        }

        private void OnGameStarted() => _uiView.OnGameStarted();

        private void OnScoreChanged(int newScore) => _uiView.UpdateScore(newScore);

        private void OnGameOver() => _uiView.OnGameOver();

        private void OnDestroy()
        {
            _gameManager.OnGameStartEvent -= OnGameStarted;
            _gameManager.OnGameOverEvent -= OnGameOver;
            _scoreController.OnScoreChangedEvent -= OnScoreChanged;
        }
    }
}