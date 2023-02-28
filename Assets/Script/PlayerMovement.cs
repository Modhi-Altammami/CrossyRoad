using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
       
        if(isMoving) return;    
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            jump();
            transform.position += Vector3.left;
           // transform.eularAngular = new Vector3(0, -90, 0);


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            jump();
            transform.position += Vector3.right;
           // transform.eularAngular = new Vector3(0,90,0);      

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
            transform.position += Vector3.forward;
          //  transform.eularAngular = new Vector3(0, 0, 0);


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            jump();
            transform.position += Vector3.back;
           // transform.eularAngular = new Vector3(0, 180, 0);

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

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over: "+collision);
    }
}



