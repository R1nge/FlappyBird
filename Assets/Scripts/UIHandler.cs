using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI score, highScore;
    public Button playButton, retryButton;
    private SpriteRenderer _gameOver;
    

    private void Awake()
    {
        _gameOver = GameObject.Find("GameOver").GetComponent<SpriteRenderer>();
        _gameOver.enabled = false;

        UpdateScore(0);
    }

    public void StartGame()
    {
        playButton.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        score.gameObject.SetActive(true);
    }


    public void GameOver()
    {
        highScore.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        _gameOver.enabled = true;
    }
    

    public void UpdateScore(int currentScore)
    {
        score.text = currentScore.ToString();
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }
}