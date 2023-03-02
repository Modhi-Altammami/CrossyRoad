using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    [SerializeField] float target;
    void Update()
    {
        transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        if (gameObject.transform.position.x > target || gameObject.transform.position.x <-1* target)
        {
            Destroy(gameObject);
        }
    }
   
}
