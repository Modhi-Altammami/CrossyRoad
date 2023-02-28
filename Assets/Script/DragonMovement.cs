using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = new Vector3(10f, transform.position.y, transform.position.z);
        StartCoroutine(MoveFunction());
    }

    IEnumerator MoveFunction()
    {

        while (true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, 0.0035f);

            // If the object has arrived, stop the coroutine
            if (gameObject.transform.position.x > target.x)
            {
                yield break;
            }

            // Otherwise, continue next frame

            yield return null;
        }
    }
}
