using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] private AudioSource score, gameOver;

    public void PlayScoreSound()
    {
        score.Play(0);
    }

    public void PlayGameOverSound()
    {
        gameOver.Play(0);
    }
}