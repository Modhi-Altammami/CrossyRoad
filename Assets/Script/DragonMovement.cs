using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    Vector3 target;
    [SerializeField] bool isRoad;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(50f, transform.position.y, transform.position.z);
       // StartCoroutine(MoveFunction());
    }


    void Update()
    {

        if(isRoad) {
            transform.Translate(Vector3.forward * 4f * Time.deltaTime);
                
        }
        else
        {
            transform.Translate(Vector3.right * 10f * Time.deltaTime);
         
        }
        if (gameObject.transform.position.x > target.x)
        {
            Destroy(gameObject);
        }
    }
   
}
