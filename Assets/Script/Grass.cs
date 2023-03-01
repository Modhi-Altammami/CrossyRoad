using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grass : MonoBehaviour
{

    [SerializeField] GameObject[] Trees;
    [SerializeField] Transform treeParent;
    int temp;
    int posholder;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i < 4; i++)
        {
            if (i % 2 == 0)
                temp = Random.Range(-10, -2) + i*-4;
            else
                temp = Random.Range(2, 10) + i*4;

            Instantiate(
                Trees[Random.Range(0, Trees.Length)], 
                new Vector3(temp, treeParent.position.y, treeParent.position.z), 
                Quaternion.identity, treeParent);
        }
    }

    
}
