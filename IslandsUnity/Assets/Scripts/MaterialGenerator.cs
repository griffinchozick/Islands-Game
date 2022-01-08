using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DataSource for Island Model
public class MaterialGenerator : MonoBehaviour
{
    [SerializeField] Material[] matPrefabs;
    public List<Material> MaterialQueue;
    public int DefaultBagSize = 8;

    public Material NextMaterial {
        get
        {
            if (MaterialQueue.Count.Equals(0))
                CreateRandomizedBag(DefaultBagSize);
            return MaterialQueue[0];
        }
    }

    public void CreateRandomizedBag(int bagSize)
    {
        int upperLimit = matPrefabs.Length;
        for (int i = 0; i < bagSize; i++)
        {
            var newMat = Instantiate(matPrefabs[Random.Range(0, upperLimit)], new Vector3(0, 0, 0), Quaternion.identity);
            newMat.transform.SetParent(transform, false);
            MaterialQueue.Add(newMat.GetComponent<Material>());
        }
    }

    //Returns the next material but also removes that material from the list
    public Material GetNextMaterial()
    {
        Material nextMaterial = NextMaterial;
        MaterialQueue.RemoveAt(0);
        return nextMaterial;
    }
}
