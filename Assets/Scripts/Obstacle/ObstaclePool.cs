using System;
using System.Collections.Generic;
using UnityEngine;

// I used "Object Pooling" to reduce RAM usage

public class ObstaclePool : MonoBehaviour
{
    #region Pool

    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #endregion

    [SerializeField] private Pool pool;
    private Dictionary<string, Queue<GameObject>> _obstacles;

    #region Singleton

    public static ObstaclePool Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    private void Start()
    {
        _obstacles = new Dictionary<string, Queue<GameObject>>();

        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < pool.size; i++)
        {
            var tmp = Instantiate(pool.prefab);
            tmp.SetActive(false);
            objectPool.Enqueue(tmp);
        }

        _obstacles.Add(pool.tag, objectPool);
    }


    public void SpawnFromPool(string tag, Vector2 position, Quaternion rotation)
    {
        var objectToSpawn = _obstacles[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetPositionAndRotation(position, rotation);

        _obstacles[tag].Enqueue(objectToSpawn);
    }
}