using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script{
    public class EnemyDie : MonoBehaviour
    {
        public bool PauseGame;
        [SerializeField] private GameObject gameOwerLost;
        [SerializeField] private GameObject gameOwerWon;
        [SerializeField] private GameObject pause;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        public int map;
        [SerializeField] private float monets;
        private System.Random r = new System.Random();
        void Start()
        {
           
            map = r.Next(1, 3);

           
            if (PlayerPrefs.HasKey("diePlayer")==false && PlayerPrefs.HasKey("diePlayer") == false)
            {
                    monets = PlayerPrefs.GetFloat("dieEnemy") - PlayerPrefs.GetFloat("diePlayer");
                    if (PlayerPrefs.GetFloat("MonetsPlayerEnemy") < monets)
                    {
                        PlayerPrefs.SetFloat("MonetsPlayer", PlayerPrefs.GetFloat("diePlayer"));
                        PlayerPrefs.SetFloat("MonetsEnemy", PlayerPrefs.GetFloat("dieEnemy"));
                        PlayerPrefs.SetFloat("MonetsPlayerEnemy", monets);

                    }
            }
            else
            {
                PlayerPrefs.SetFloat("MonetsPlayerEnemy", 0);
                PlayerPrefs.SetFloat("diePlayer",0f);
                PlayerPrefs.SetFloat("dieEnemy",0f);

            }
        }

        void Update()
        {
            if (map == 1)
            {
                level1.SetActive(true);
            }
            else if (map == 2)
            {
                level2.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (PauseGame)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            monets = PlayerPrefs.GetFloat("dieEnemy") - PlayerPrefs.GetFloat("diePlayer");
            if (PlayerPrefs.HasKey("MonetsPlayerEnemy"))
            {
                if (PlayerPrefs.GetFloat("MonetsPlayerEnemy") < monets)
                {
                    PlayerPrefs.SetFloat("MonetsPlayer", PlayerPrefs.GetFloat("diePlayer"));
                    PlayerPrefs.SetFloat("MonetsEnemy", PlayerPrefs.GetFloat("dieEnemy"));
                    PlayerPrefs.SetFloat("MonetsPlayerEnemy", monets);

                }
            }

        }
        public void Resume()
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = false;
            

        }
        public void NextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            monets = PlayerPrefs.GetFloat("dieEnemy") - PlayerPrefs.GetFloat("diePlayer");
            if (PlayerPrefs.HasKey("MonetsPlayerEnemy"))
            {
                if (PlayerPrefs.GetFloat("MonetsPlayerEnemy") < monets)
                {
                    PlayerPrefs.SetFloat("MonetsPlayer", PlayerPrefs.GetFloat("diePlayer"));
                    PlayerPrefs.SetFloat("MonetsEnemy", PlayerPrefs.GetFloat("dieEnemy"));
                    PlayerPrefs.SetFloat("MonetsPlayerEnemy", monets);
                }

                PlayerPrefs.SetFloat("diePlayer", 0f);
            }
        }
        public void ResetLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        public void Pause()
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
        }
  

        public void LosdMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Menu");
            monets = PlayerPrefs.GetFloat("dieEnemy") - PlayerPrefs.GetFloat("diePlayer") ;
            if (PlayerPrefs.HasKey("MonetsPlayerEnemy"))
            {
                if (PlayerPrefs.GetFloat("MonetsPlayerEnemy") < monets)
                {
                    PlayerPrefs.SetFloat("MonetsPlayer", PlayerPrefs.GetFloat("diePlayer"));
                    PlayerPrefs.SetFloat("MonetsEnemy", PlayerPrefs.GetFloat("dieEnemy"));
                    PlayerPrefs.SetFloat("MonetsPlayerEnemy", monets);
                }
            }
            PlayerPrefs.SetFloat("diePlayer", 0f);
            PlayerPrefs.SetFloat("dieEnemy", 0f);
        }
    }

}