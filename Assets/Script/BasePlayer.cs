using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class BasePlayer : MonoBehaviour
    {
        [SerializeField] private GameObject GameOwerLost;
        [SerializeField] private Transform point;
        [SerializeField] private GameObject gamer_obj;
        [SerializeField] private int health=100;
      // public int DieNumber;


        [SerializeField] public Text NumberPlayer;

        public bool PauseGame { get; private set; }

        void Start()
        {
            GameObject gamer;
            gamer = Instantiate(gamer_obj, point.position, Quaternion.identity);

            gamer.GetComponent<PlayerFriendsConroller>().GamePlayer = 1;
            //gamer.GetComponent<PlayerFriendsConroller>().point= point;
           // PlayerPrefs.SetFloat("diePlayer", 0);
          

            NumberPlayer.text = "0";
        }

        void Update()
        {
            if (health < 1)
            {
                Die();
            }
            NumberPlayer.text = ""+ PlayerPrefs.GetFloat("diePlayer");

        }

        public void Gamer(int gamePlayer)
        {
            PlayerPrefs.SetFloat("diePlayer", PlayerPrefs.GetFloat("diePlayer") + 1);
            if (gamePlayer <= 29)
            {
                GameObject gamer;
                gamer = Instantiate(gamer_obj,point.position, Quaternion.identity);
                gamePlayer += 1;
                PlayerPrefs.SetFloat("diePlayer", PlayerPrefs.GetFloat("diePlayer")+1);
            
                gamer.GetComponent<PlayerFriendsConroller>().GamePlayer = gamePlayer;
            }
            else
            {
                GameOwerLost.SetActive(false);
                Time.timeScale = 1f;
                PauseGame = false;
            }
        }
       public void Die()
        {
            GameOwerLost.SetActive(true);
            Time.timeScale=0f;
            Destroy(this.gameObject);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}