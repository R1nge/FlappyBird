using Core;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private readonly Vector2 _force = new Vector2(0, 5);
        private GameManager _gameManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _gameManager = FindObjectOfType<GameManager>();
            enabled = false;
            _rigidbody.isKinematic = true;
            _gameManager.OnGameStartEvent += OnStartGame;
            _gameManager.OnGameOverEvent += OnGameOver;
        }

        private void OnStartGame()
        {
            enabled = true;
            _rigidbody.isKinematic = false;
        }

        private void OnGameOver()
        {
            enabled = false;
            _rigidbody.isKinematic = true;
        }

        public void ApplyImpulse() => _rigidbody.AddForce(_force, ForceMode2D.Impulse);

        private void OnDestroy()
        {
            _gameManager.OnGameStartEvent -= OnStartGame;
            _gameManager.OnGameOverEvent -= OnGameOver;
        }
    }
}