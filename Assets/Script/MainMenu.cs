using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }
        public void ExitGame()
        {
            Debug.Log("Игра закончилась");
            Application.Quit();
        }

    }
}