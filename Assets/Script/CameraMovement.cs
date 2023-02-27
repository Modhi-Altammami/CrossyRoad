using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] Transform player;
    [SerializeField] float smoothSpeed;
    Vector3 offset;
    Vector3 targetPos;
    Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        offset = startPos - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();

    }

    void followPlayer()
    {
        startPos = transform.position;
        targetPos = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(startPos, targetPos, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
