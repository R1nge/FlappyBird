using Core;
using Interfaces;
using UnityEngine;
using VContainer;

namespace Player
{
    public class PlayerTilt : MonoBehaviour, IRotatable
    {
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
        }

        private void FixedUpdate()
        {
            if(!_gameManager.HasGameStarted()) return;
            Rotate();
        }

        public void Rotate()
        {
            if (_rigidbody.velocity.y < 0)
            {
                TiltDown();
            }
            else
            {
                TiltUp();
            }
        }

        private void TiltUp()
        {
            if (transform.rotation.z <= 30)
            {
                transform.rotation =
                    Quaternion.RotateTowards(
                        transform.rotation,
                        Quaternion.Euler(0, 0, -30),
                        Time.deltaTime * 100);
            }
        }

        private void TiltDown()
        {
            if (transform.rotation.z >= -30)
            {
                transform.rotation =
                    Quaternion.RotateTowards(
                        transform.rotation,
                        Quaternion.Euler(0, 0, 30),
                        Time.deltaTime * 100);
            }
        }
    }
}