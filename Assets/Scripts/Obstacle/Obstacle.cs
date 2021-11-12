using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameLoop _gameLoop;

    private void Awake()
    {
        _gameLoop = FindObjectOfType<GameLoop>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _gameLoop.GameOver();
    }
}