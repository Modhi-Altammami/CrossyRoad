using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace modi.crossyRoad
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// the game manager handels when the player loses
        /// </summary>
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
}