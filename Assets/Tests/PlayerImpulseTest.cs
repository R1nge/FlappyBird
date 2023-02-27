using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerImpulseTest
    {
        [UnityTest]
        public IEnumerator Impulse()
        {
            var playerGo = new GameObject();
            var rigidBody = playerGo.AddComponent<Rigidbody2D>();
            rigidBody.mass = 1;
            rigidBody.gravityScale = 1;
            var force = new Vector2(0, 5);
            
            rigidBody.AddForce(force, ForceMode2D.Impulse);
            
            yield return new WaitForEndOfFrame();

            Assert.AreEqual(force, rigidBody.velocity);
        }
    }
}