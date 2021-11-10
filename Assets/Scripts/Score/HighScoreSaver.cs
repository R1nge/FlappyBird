using UnityEngine;

public class HighScoreSaver : MonoBehaviour
{
    public int currentScore;

    private void Start()
    {
        currentScore = 0;
    }

    public void SaveHighScore(int newScore)
    {
        var highScore = PlayerPrefs.GetInt("HighScore", 0);
        bool gotNewHighScore = newScore > highScore;

        if (gotNewHighScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            PlayerPrefs.Save();
        }
    }
}