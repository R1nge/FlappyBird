using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    private HighScoreSaver _highScoreSaver;
    private UIHandler _uiHandler;
    private SoundHandler _soundHandler;

    private void Awake()
    {
        _highScoreSaver = FindObjectOfType<HighScoreSaver>();
        _uiHandler = FindObjectOfType<UIHandler>();
        _soundHandler = FindObjectOfType<SoundHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ObstaclePool.Instance.SpawnFromPool("Obstacle", new Vector2(transform.position.x + 5, Random.Range(-2.27f, 2.48f)), Quaternion.identity);
        _highScoreSaver.currentScore += 1;
        _uiHandler.UpdateScore(_highScoreSaver.currentScore);
        _soundHandler.PlayScoreSound();
    }
}