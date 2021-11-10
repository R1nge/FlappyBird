using System;
using System.Collections.Generic;
using UnityEngine;

// I used "Object Pooling" because i can,
// but it also can be done using Instantiate() and Destroy().

public class ObstaclePool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    [SerializeField] private List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> _obstacles;

    //Singleton
    public static ObstaclePool Instance;

    private void Awake()
    {
        Instance = this;

        _obstacles = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                var tmp = Instantiate(pool.prefab);
                tmp.SetActive(false);
                objectPool.Enqueue(tmp);
            }

            _obstacles.Add(pool.tag, objectPool);
        }
    }


    public void SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        var objectToSpawn = _obstacles[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);

        _obstacles[tag].Enqueue(objectToSpawn);
    }
}