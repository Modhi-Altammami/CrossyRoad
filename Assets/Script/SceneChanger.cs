using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace modi.crossyRoad
{
    public class SceneChanger : MonoBehaviour
    {
        /// <summary>
        /// the script that handels the scene transitions in the game in (for UI buttons)
        /// </summary>
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }

        public void GoBack()
        {
            SceneManager.LoadScene("Intro");
        }


    }
}