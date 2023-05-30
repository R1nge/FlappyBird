using Core;
using UnityEngine;
using VContainer;

namespace Score
{
    public class ScoreIncreaser : MonoBehaviour
    {
        [SerializeField] private int amount;
        private ScoreController _scoreController;
        
        [Inject]
        private void Construct(ScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        private void OnTriggerEnter2D(Collider2D other) => _scoreController.IncreaseScore(amount);
    }
}