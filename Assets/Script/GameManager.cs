using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player player;



    void Awake()
    {
          player.GameOverEvent += GameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void GameOver()
    {
        Debug.Log("gWWW");
    }
}
