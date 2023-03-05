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
    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
