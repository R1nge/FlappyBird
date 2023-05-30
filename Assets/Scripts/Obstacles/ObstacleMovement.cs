using Core;
using Interfaces;
using UnityEngine;
using VContainer;

namespace Obstacles
{
    public class ObstacleMovement : MonoBehaviour, IMovable
    {
        [field:SerializeField] public float Speed { get; set; }
        public Vector3 Direction { get; set; } = Vector3.left;
        private GameManager _gameManager;
        
        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Update()
        {
            if (!_gameManager.HasGameStarted()) return;
            Move();
        }

        public void Move()
        {
            transform.Translate(Direction * (Time.deltaTime * Speed), Space.World);
            if (transform.position.x <= -6)
                transform.position = new(6, Random.Range(-2.55f, 2.55f), 0);
        }
    }
}