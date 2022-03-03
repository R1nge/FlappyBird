using Core;
using UnityEngine;

namespace Score
{
    public class ScoreIncreaser : MonoBehaviour
    {
        [SerializeField] private int amount;
        private HighScoreSaver _highScoreSaver;

        private void Awake() => _highScoreSaver = FindObjectOfType<HighScoreSaver>();

        private void OnTriggerEnter2D(Collider2D other) => _highScoreSaver.IncreaseScore(amount);
    }
}