using Core;
using Interfaces;
using UnityEngine;
using VContainer;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        private IMovable _playerMovement;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Awake() => _playerMovement = GetComponent<PlayerMovement>();

        private void Update()
        {
            if(_gameManager.HasGameEnded()) return;
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.Move();
            }

            if (Input.touchCount <= 0) return;

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _playerMovement.Move();
            }
        }
    }
}