using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Awake() => _playerMovement = FindObjectOfType<PlayerMovement>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.ApplyImpulse();
            }

            if (Input.touchCount <= 0) return;

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _playerMovement.ApplyImpulse();
            }
        }
    }
}