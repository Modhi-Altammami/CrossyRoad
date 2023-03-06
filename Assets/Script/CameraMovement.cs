using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    /// <summary>
    /// the script handels the camera movement along with the player movement (only forward, left and right)
    /// </summary>

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
        targetPos = new Vector3(targetPos.x, startPos.y, targetPos.z < startPos.z ? startPos.z : targetPos.z);
        Vector3 smoothedPosition = Vector3.Lerp(startPos, targetPos, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
