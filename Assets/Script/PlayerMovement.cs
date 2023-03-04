using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 PlayerTransform;
    //Animator m_Animator;
    bool isMoving;

    void Start()
    {
        //PlayerTransform = transform.position;
       // m_Animator = gameObject.GetComponent<Animator>();

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
           // jump();
            transform.position += Vector3.left*2;
            transform.eulerAngles = new Vector3(0, -90, 0);


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
         //   jump();
            transform.position += Vector3.right*2;
            transform.eulerAngles = new Vector3(0,90,0);      

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
         //   jump();
            transform.position += Vector3.forward*2;
             transform.eulerAngles = new Vector3(0, 0, 0);


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
         //   jump();
            transform.position += Vector3.back*2;
             transform.eulerAngles = new Vector3(0, 180, 0);

        }
    }

    void jump()
    {
       //s m_Animator.SetTrigger("activateJump");
        isMoving = true;
    }

    void endJump()
    {
        isMoving = false;
    }

    void OnTriggerEnter(Collider collision)
    {

        if(collision.tag == "GameOver")
            {
                Debug.Log("Cube Game Over: " + collision);
            }

        if (collision.tag == "Obstacle")
            {
            Debug.Log("Obstacle hit: "+ collision);
        }

        if (collision.tag == "log")
        {
            Debug.Log("log hit: " + collision);
        }

    }
}



