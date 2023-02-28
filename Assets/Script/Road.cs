using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] GameObject[] Obstacles;
    [SerializeField] Transform[] Lanes;
    [SerializeField] bool isRoad;
    GameObject temp;
    float step;
    Vector3 target = new Vector3(1, 0.5f, 0);
    void Start()
    {
        StartCoroutine(popObstacle());
      
    }

    IEnumerator popObstacle()
    {
        while (true)
        {
            GameObject Obstacle = Obstacles[Random.Range(0, Obstacles.Length)];
            Instantiate(Obstacle, Lanes[Random.Range(0, Lanes.Length)]);
            //MoveFunction(dragon);
          //  dragon.transform.Translate(target * 2f * Time.deltaTime);
            yield return new WaitForSeconds(isRoad?5:0.5f);

        }


    }

    

}
