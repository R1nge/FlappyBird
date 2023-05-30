using Core;
using Interfaces;
using UnityEngine;
using VContainer;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IMovable
    {
        [field:SerializeField] public float Speed { get; set; }
        public Vector3 Direction { get; set; } = new(0, 5);
        private Rigidbody2D _rigidbody;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.isKinematic = true;
            _gameManager.OnGameStartEvent += OnGameStarted;
            _gameManager.OnGameOverEvent += OnGameOver;
        }

        private void OnGameStarted()
        {
            _rigidbody.isKinematic = false;
        }

        public void Move() => _rigidbody.AddForce(Direction * Speed, ForceMode2D.Impulse);

        private void OnGameOver()
        {
            _rigidbody.isKinematic = true;
        }

        private void OnDestroy()
        {
            _gameManager.OnGameStartEvent -= OnGameStarted;
            _gameManager.OnGameOverEvent -= OnGameOver;
        }
    }
}