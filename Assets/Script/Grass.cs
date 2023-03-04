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
            // to disterbute the trees 4 unit
                temp = Random.Range(-20, 20) + i*5;
           

            Instantiate(
                Trees[Random.Range(0, Trees.Length)], 
                new Vector3(temp, treeParent.position.y, treeParent.position.z), 
                Quaternion.identity, treeParent);
        }
    }

    
}
