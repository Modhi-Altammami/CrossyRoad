using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] GameObject[] dragons;
    [SerializeField] Transform[] Lanes;
    GameObject temp;
    float step;
    Vector3 target = new Vector3(1, 0.5f, 0);
    void Start()
    {
        StartCoroutine(popDragon());
      
    }

    IEnumerator popDragon()
    {
        while (true)
        {
            GameObject dragon = dragons[Random.Range(0, dragons.Length)];
            Instantiate(dragon, Lanes[Random.Range(0, Lanes.Length)]);
            //MoveFunction(dragon);
          //  dragon.transform.Translate(target * 2f * Time.deltaTime);
            yield return new WaitForSeconds(5);

        }


    }

    

}
