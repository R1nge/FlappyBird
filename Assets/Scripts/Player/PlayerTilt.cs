using Core;
using UnityEngine;

namespace Player
{
    public class PlayerTilt : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            GameManager.Instance.OnGameStartEvent += OnGameStart;
            enabled = false;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnGameStart() => enabled = true;

        private void FixedUpdate() => Tilt();

        private void Tilt()
        {
            if (_rigidbody.velocity.y < 0)
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
            else
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
}