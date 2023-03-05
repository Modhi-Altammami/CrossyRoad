
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{

    Vector3 PlayerTransform;
    Animator m_Animator;
    bool isMoving;

    void Start()
    {
        //PlayerTransform = transform.position;
        m_Animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerMovement();
    }

    void CheckPlayerMovement()
    {
        if (isMoving)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left*2;
            transform.eulerAngles = new Vector3(0, -90, 0);
            jump();

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right*2;
            transform.eulerAngles = new Vector3(0,90,0);
            jump();

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward*2;
            transform.eulerAngles = new Vector3(0, 0, 0);
            jump();
            Player.instance.hitRaycast();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += Vector3.back*2;
            transform.eulerAngles = new Vector3(0, 180, 0);
            jump();
            Player.instance.hitRaycast();

        }
    }

    void jump()
    {
        m_Animator.SetTrigger("activateJump");
        isMoving = true;
    }

    void endJump()
    {
        isMoving = false;
    }

   
    }




