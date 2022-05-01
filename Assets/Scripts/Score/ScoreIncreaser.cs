using Core;
using UnityEngine;

namespace Score
{
    public class ScoreIncreaser : MonoBehaviour
    {
        [SerializeField]private int amount;
        private ScoreController _scoreController;

        private void Awake() => _scoreController = FindObjectOfType<ScoreController>();

        private void OnTriggerEnter2D(Collider2D other) => _scoreController.IncreaseScore(amount);
    }
}