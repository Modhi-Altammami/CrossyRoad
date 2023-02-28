using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grass : MonoBehaviour
{

    [SerializeField] GameObject[] Trees;
    int temp;
    [SerializeField] Transform treeParent;

    //List<GameObject> ActiveTrees;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i < 4; i++)
        {
            if (i % 2 == 0)
                temp = Random.Range(-10, -2) + i;
            else
                temp = Random.Range(2, 10) + i;

            Instantiate(
                Trees[Random.Range(0, Trees.Length)], 
                new Vector3(temp, -1.4f, 0), 
                Quaternion.identity, treeParent);
        }
    }

    
}
