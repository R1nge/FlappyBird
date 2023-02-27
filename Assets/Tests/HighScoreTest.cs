using System.Collections;
using Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HighScoreTest
    {
        [UnityTest]
        public IEnumerator New_HighScore()
        {
            var scoreControllerGo = new GameObject();
            var scoreController = scoreControllerGo.AddComponent<ScoreController>();
            int currentScore = 0;
            var previousHighScore = 0;
            scoreController.OnScoreChangedInt += newScore => { currentScore = newScore; };
            
            scoreController.IncreaseScore(1);
            
            yield return null;
            
            Assert.Greater(currentScore, previousHighScore);
        }
    }
}