using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    bool onLog;
    bool onRiver;
    bool onDead;
    Animator m_Animator;
    Ray ray;
    Vector3 direction;
    public event Action GameOverEvent;
    public static Player instance;

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

    }
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
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
            onDead= true;
            return;
        }

        if (onLog)
        {
            transform.Translate(Vector3.forward * 10f * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Obstacle")
        {
            Debug.Log("Obstacle hit: " + collision);
            m_Animator.SetTrigger("Died");
            onDead= true;
        }
    }


   public void hitRaycast()
    {
        direction = Vector3.down;
        Debug.Log("hitRaycast");

        ray = new Ray(transform.position, direction);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData))
            {
            Debug.Log(hitData.collider.gameObject.name);
            Debug.Log(transform.position);
            if (hitData.collider.gameObject.tag == "log")
                {
                    transform.eulerAngles = new Vector3(0, hitData.collider.gameObject.transform.eulerAngles.y, 0);
                    onLog = true;

                }

              else  if (hitData.collider.gameObject.tag == "river")
                {
                    m_Animator.SetTrigger("Drown");
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

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        GameOverEvent?.Invoke();
    }


    void Dead()
    {
        GameOverEvent?.Invoke();

    }

}
