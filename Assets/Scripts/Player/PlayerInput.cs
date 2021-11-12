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
        if (_playerMovement != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _playerMovement.ApplyImpulse();
            }

            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);

                    if (touch.phase == TouchPhase.Began)
                    {
                        _playerMovement.ApplyImpulse();
                    }
                }
            }
        }
    }
}