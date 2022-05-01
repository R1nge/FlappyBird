using Core;
using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other) => GameManager.Instance.GameOver();
    }
}