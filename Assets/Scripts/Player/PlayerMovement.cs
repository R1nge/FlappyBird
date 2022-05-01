using Core;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private readonly Vector2 _force = new Vector2(0, 5);

        private void Awake()
        {
            GameManager.Instance.OnGameStartEvent += OnStartGame;
            GameManager.Instance.OnGameOverEvent += OnGameOver;
            _rigidbody = GetComponent<Rigidbody2D>();
            enabled = false;
            _rigidbody.isKinematic = true;
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
    }
}