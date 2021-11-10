using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_playerMovement != null)
                {
                    _playerMovement.ApplyImpulse();
                }
            }

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);

                    if (touch.phase == TouchPhase.Began)
                    {
                        if (_playerMovement != null)
                        {
                            _playerMovement.ApplyImpulse();
                        }
                    }
                }
            }
        }
    }
}