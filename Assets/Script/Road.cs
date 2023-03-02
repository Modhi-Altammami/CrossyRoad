using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{

    [SerializeField] GameObject[] Obstacles;
    [SerializeField] Transform Lanes;
    [SerializeField] bool isRoad;
 
    void Start()
    {
        StartCoroutine(popObstacle());
      
    }

    IEnumerator popObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 4));
            GameObject Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            Instantiate(Obstacle, Lanes);
            yield return new WaitForSeconds(Random.Range(3, 11));

        }


    }

    

}
