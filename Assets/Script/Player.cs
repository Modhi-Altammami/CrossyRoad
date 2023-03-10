using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace modi.crossyRoad
{
    public class Player : MonoBehaviour
    {
        /// <summary>
        /// This script handels all the player interaction with the colliders
        /// and send to game managers if the user is hit by an obstecals or go overboared the allowed area.
        /// </summary>

        //the bool variables is to determine wither the player is on a specific condition (log , river , death)
        public bool onLog;
        bool onRiver;
        public bool onDead;
        Animator m_Animator;
        Ray ray;
        public event Action GameOverEvent;
        public static Player instance;
        PlayerMovement player;
        AudioSource loseMusic;
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            player = gameObject.GetComponent<PlayerMovement>();
            loseMusic = gameObject.GetComponent<AudioSource>();

        }
        void Start()
        {
            m_Animator = gameObject.GetComponent<Animator>();
            player.PlayerForward += hitRaycast;
            

        }

        // Update is called once per frame
        void Update()
        {
            if (onDead)
            {
                StartCoroutine(wait());

            }
            if (onRiver)
            {
                transform.Translate(Vector3.down * 5f * Time.deltaTime);
                onDead = true;
                return;
            }

            if (onLog)
            {
                transform.Translate(Vector3.forward * 10f * Time.deltaTime);
                if (transform.position.x < -15 || transform.position.x > 15)
                {
                    m_Animator.SetTrigger("Dizzy");
                    onDead = true;
                }
            }
        }

        void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Obstacle")
            {
                Debug.Log("Obstacle hit: " + collision);
                m_Animator.SetTrigger("Died");
                loseMusic.Play();
                onDead = true;
            }
        }

        // call this method if the user press forward
        public void hitRaycast()
        {
            ray = new Ray(transform.position, Vector3.down);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData))
            {
                if (hitData.collider.gameObject.tag == "log")
                {
                    transform.eulerAngles = new Vector3(0, hitData.collider.gameObject.transform.eulerAngles.y, 0);
                    onLog = true;

                }

                else if (hitData.collider.gameObject.tag == "river")
                {
                    m_Animator.SetTrigger("Dizzy");
                    loseMusic.Play();
                    Debug.Log("river hit: " + hitData.collider.gameObject.tag);
                    onRiver = true;
                    onLog = false;
                }

            }
            else
            {
                onLog = false;
            }

        }

        //wait for 3 seconds before going to the game over scene
        IEnumerator wait()
        {
            yield return new WaitForSeconds(3);
            Dead();
        }


        void Dead()
        {
            GameOverEvent?.Invoke();
        }

    }

}
