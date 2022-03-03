using Core;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private GameManager _gameManager;
        public bool canMove;
        private void Awake() => _gameManager = FindObjectOfType<GameManager>();

        private void OnCollisionEnter2D(Collision2D other) => _gameManager.GameOver();
    }
}