using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialGenerator : MonoBehaviour
{
    [SerializeField] GameObject matPrefab;


    public Material StandardMaterial { 
        get
        {
            var newMat = Instantiate(matPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            return newMat.GetComponent<Material>();
        } 
    }
   
}
