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
        Ray ray;
        Vector3 direction;
        public event Action PlayerForward;
        void Start()
        {
            //PlayerTransform = transform.position;
            //m_Animator = gameObject.GetComponent<Animator>();

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
                transform.eulerAngles = new Vector3(0, -90, 0);
               if(!TreehitRaycast()) 
                { 
                transform.position += Vector3.left * 2;
                // jump();
                }

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.eulerAngles = new Vector3(0, 90, 0);
                if (!TreehitRaycast())
                {
                    transform.position += Vector3.right * 2;
                    //jump();
                }
            

            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                if (!TreehitRaycast())
                {
                    transform.position += Vector3.forward * 2;
                    //  jump();
                    PlayerForward?.Invoke();
                }  
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                if (!TreehitRaycast())
                {
                    transform.position += Vector3.back * 2;
                    //  jump();
                    PlayerForward?.Invoke();
                }


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

        public bool TreehitRaycast()
        {
            direction = transform.forward;

            ray = new Ray(transform.position, direction);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData , 2f))
            {
                if (hitData.collider.gameObject.tag == "tree")
                {
                    Debug.Log(hitData.collider.gameObject.name);
                    return true;
                }
            }
            return false;

        }
    }
}



