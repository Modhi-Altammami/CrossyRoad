using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    /// <summary>
    /// the script handels the mobster and log movement and destroy it if the object crosses the target position which is the end of the screen
    /// 
    /// </summary>
    [SerializeField] float target;
    void Update()
    {
        transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        // if the object reaches the end of each side of the lane it will get destroyed
        if (gameObject.transform.position.x > target || gameObject.transform.position.x <-1* target)
        {
            Destroy(gameObject);
        }
    }
   
}
