using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private HighScoreSaver _highScoreSaver;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _highScoreSaver = FindObjectOfType<HighScoreSaver>();
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _highScoreSaver.SaveHighScore(_highScoreSaver.currentScore);
        _uiHandler.GameOver();
    }
}