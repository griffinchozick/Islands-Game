using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGenerator : MonoBehaviour
{
    [SerializeField] Material[] matPrefabs;
    public List<Material> MaterialQueue;


    public Material NextMaterial {
        get
        {
            return MaterialQueue[0];
        }
    }
    private void Awake()
    {
        CreateRandomizedBag(8);
    }

    public void CreateRandomizedBag(int bagSize)
    {
        int upperLimit = matPrefabs.Length;
        for (int i = 0; i < bagSize; i++)
        {
            var newMat = Instantiate(matPrefabs[Random.Range(0, upperLimit)], new Vector3(0, 0, 0), Quaternion.identity);
            MaterialQueue.Add(newMat.GetComponent<Material>());
        }
    }

    public Material GetNextMaterial()
    {
        Material nextMaterial = MaterialQueue[0];
        MaterialQueue.RemoveAt(0);
        return nextMaterial;
    }
}
