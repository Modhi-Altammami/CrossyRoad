using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace modi.crossyRoad
{
    public class GameManager : MonoBehaviour
    {

        /// <summary>
        /// the game manager handels when the player loses
        /// </summary>
        [SerializeField] Player player;
        [SerializeField] PlayerMovement score;
        [SerializeField] TMP_Text scoreText;
        int temp;
        float playerPos;
        float PrevPlayerPosition;
        void Awake()
        {
            temp = 0;
            player.GameOverEvent += GameOver;
            score.PlayerForward += UpdateScore;
        }
        void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }

        void UpdateScore()
        {
            playerPos = player.gameObject.transform.position.z;
            if (PrevPlayerPosition < playerPos)
            {
                temp++;
                scoreText.text = temp.ToString();
                PrevPlayerPosition = playerPos;
            }
            
        }

        
    }
}