using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{

    [SerializeField] GameObject[] Obstacles;
    [SerializeField] Transform Lanes;
    int randomDir;
 

    void Awake()
    {
        randomDir = Random.Range(0, 2);
    }
    void Start()
    {
       
        Debug.Log(randomDir);
        StartCoroutine(popObstacle());
      
    }

    IEnumerator popObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0, 4));
            GameObject Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            if (randomDir==1)
            {
                Obstacle.transform.position = new Vector3(0.45f, 0.5f, 0);
                Obstacle.transform.eulerAngles = new Vector3(0, -90, 0);
            }
            else
            {
                Obstacle.transform.position = new Vector3(-0.45f, 0.5f, 0);
                Obstacle.transform.eulerAngles = new Vector3(0, 90, 0);
            }
            Instantiate(Obstacle, Lanes);
            yield return new WaitForSeconds(Random.Range(3, 11));

        }


    }

    

}
