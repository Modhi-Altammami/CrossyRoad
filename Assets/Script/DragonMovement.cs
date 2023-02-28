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
        target = new Vector3(isRoad?10f:30f, transform.position.y, transform.position.z);
        StartCoroutine(MoveFunction());
    }

    IEnumerator MoveFunction()
    {

        while (true)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target, isRoad?0.0035f:0.003f);

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
