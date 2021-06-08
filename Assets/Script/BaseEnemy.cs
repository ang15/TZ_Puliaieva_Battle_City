using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject GameOwerWon;
        [SerializeField] private Transform gamerPoint;

        [SerializeField] private Transform gamerPoint2;
        [SerializeField] private GameObject gamer_obj;

     //        [SerializeField] private GameObject gamer_obj2;
        [SerializeField] private int health=100;
    //    private Transform point;

        public Transform GamerPoint { get => gamerPoint; set => gamerPoint = value; }
        public Transform GamerPoint2 { get => gamerPoint2; set => gamerPoint2 = value; }
        [SerializeField] private Text NumberPlayer;
  


        //[SerializeField] private Enemy gamer_controller;
        //[SerializeField] private Enemy gamer_controller2;
        void Start()
        {
            gameObject.layer = 14;
            GameObject gamer;
            gamer = Instantiate(gamer_obj, GamerPoint.position, Quaternion.identity);
            gamer.GetComponent<Enemy>().GamePlayer = 1;
            gamer.GetComponent<Enemy>().Point = GamerPoint;

            GameObject gamer2;
            gamer2 = Instantiate(gamer_obj, GamerPoint2.position, Quaternion.identity);
            gamer2.GetComponent<Enemy>().GamePlayer = 1;
            gamer.GetComponent<Enemy>().Point = GamerPoint2;
        
          //  PlayerPrefs.SetFloat("dieEnemy", 0);
            NumberPlayer.text = "";
        }

        
        void Update()
        {
            if (health < 1)
            {
                Die();
            }

            NumberPlayer.text = "" + PlayerPrefs.GetFloat("dieEnemy");
        }
        public void Gamer(int gamePlayer, Transform pointOld)
        {
            PlayerPrefs.SetFloat("dieEnemy", PlayerPrefs.GetFloat("dieEnemy")+1);
            if (gamePlayer <= 14)
            {
                if (gamePlayer%2==0)
                {

                    GameObject gamer;

                    gamer = Instantiate(gamer_obj, GamerPoint.position, Quaternion.identity);
                    gamePlayer += 1;
                    gamer.GetComponent<Enemy>().GamePlayer = gamePlayer;

                    gamer.GetComponent<Enemy>().Point = pointOld;
                }
                else 
                {

                    GameObject gamer;

                    gamer = Instantiate(gamer_obj, GamerPoint2.position, Quaternion.identity);
                    gamePlayer += 1;
                    gamer.GetComponent<Enemy>().GamePlayer = gamePlayer;

                    gamer.GetComponent<Enemy>().Point = pointOld;

                  

                }

            }
        }
     

        public void Die()
        {
            GameOwerWon.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this.gameObject);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }

}