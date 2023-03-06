using UnityEngine;
using System;

namespace modi.crossyRoad
{
    public class PlayerMovement : MonoBehaviour
    {
        /// <summary>
        /// the  script handels the player movement 
        /// </summary>

        Vector3 PlayerTransform;
        Animator m_Animator;
        bool isMoving;
        public event Action PlayerForward;
        float PrevPlayerPosition;
        void Start()
        {
            //PlayerTransform = transform.position;
            //m_Animator = gameObject.GetComponent<Animator>();
            PrevPlayerPosition= transform.position.z;

        }

        // Update is called once per frame
        void Update()
        {
            if (!Player.instance.onDead)
            {
                CheckPlayerMovement();

            }
        }

        void CheckPlayerMovement()
        {
            if (isMoving)
            {
                return;
            }

            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * 2;
                transform.eulerAngles = new Vector3(0, -90, 0);
                // jump();

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * 2;
                transform.eulerAngles = new Vector3(0, 90, 0);
                //jump();

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position += Vector3.forward * 2;
                transform.eulerAngles = new Vector3(0, 0, 0);
                //  jump();
               
                PlayerForward?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position += Vector3.back * 2;
                transform.eulerAngles = new Vector3(0, 180, 0);
                //  jump();
                PlayerForward?.Invoke();


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
}



