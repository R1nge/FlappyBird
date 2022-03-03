using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Obstacles
{
    public class ObstaclesMovementController : MonoBehaviour
    {
        [SerializeField] private List<Obstacle> obstacles;
        [SerializeField] private float speed;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
            _gameManager.OnGameStartEvent += FindObstacles;
        }

        private void FindObstacles()
        {
            var obstaclesArray = FindObjectsOfType<Obstacle>();
            var obstacleCount = obstaclesArray.Length;
            for (int i = 0; i < obstacleCount; i++)
            {
                if (obstaclesArray[i].canMove)
                    obstacles.Add(obstaclesArray[i]);
            }
        }

        private void Update()
        {
            for (var i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i].transform.position.x > -3.5f)
                {
                    obstacles[i].transform.Translate(Vector3.left * (Time.deltaTime * speed), Space.World);
                }
                else
                {
                    var pos = obstacles[i].transform.position;
                    pos = new Vector3(5, 0, 0);
                    obstacles[i].transform.position = pos;
                    obstacles[i].transform.position =
                        new Vector3(obstacles[i].transform.position.x, Random.Range(-2.5f, 2.5f),
                            obstacles[i].transform.position.z);
                }
            }
        }
    }
}