using Core;
using UnityEngine;
using VContainer;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnCollisionEnter2D() => _gameManager.GameOver();
    }
}