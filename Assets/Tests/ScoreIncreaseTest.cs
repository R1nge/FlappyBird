using System.Collections;
using Core;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreIncreaseTest
    {
        [UnityTest]
        public IEnumerator Score_Increased_By_One()
        {
            var scoreControllerGo = new GameObject();
            var scoreController = scoreControllerGo.AddComponent<ScoreController>();
            var currentScore = 0;
            scoreController.OnScoreChangedInt += newScore => { currentScore = newScore; };

            scoreController.IncreaseScore(1);
            
            yield return null;
            
            Assert.AreEqual(1, currentScore);
        }
    }
}