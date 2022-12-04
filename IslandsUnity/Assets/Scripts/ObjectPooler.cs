using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{/*
    //Creates object pools for each material type
    [System.Serializable]
    public class MaterialPool
    {
        public Material.MatType tag;
        public GameObject prefab;
        public int size;
    }

    public Dictionary<Material.MatType, Queue<GameObject>> poolDictionary;
    public List<MaterialPool> poolList;

    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    private void Start()
    {
        poolDictionary = new Dictionary<Material.MatType, Queue<GameObject>>();

        foreach (MaterialPool pool in poolList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(Material.MatType tag, Vector3 position, Quaternion roation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + " doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = roation;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;

    }
}*/
}
