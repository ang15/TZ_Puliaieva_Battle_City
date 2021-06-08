using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class BulletEnemy : MonoBehaviour
    {
       
        [SerializeField] private int damage = 10; 
        public string direction = "left";
        [SerializeField] public float speed=100;
         public string owner = "none";

        [SerializeField] private bool onStone = false;
        [SerializeField] private LayerMask stone1;
        [SerializeField] private LayerMask stone2;
        [SerializeField] private LayerMask stone3;
        [SerializeField] private Transform stoneCheck;
        [SerializeField] private float stoneCheckRadius;

        [SerializeField] private LayerMask player;
        [SerializeField] private LayerMask playerFriends;
        //[SerializeField] private LayerMask  enemy;


        private float div=12f;
        
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, 5f);
        }

        private void FixedUpdate()
        {
            CheckingStone();
            if (onStone)
            {
                Destroy(this.gameObject);
            }

                RaycastHit2D hit2DP = Physics2D.Raycast(transform.position, transform.up, div, player);
                if (hit2DP.collider != null)
                {

                    if (hit2DP.collider.CompareTag("Player"))
                    {

                        hit2DP.collider.GetComponent<PlayerController>().TakeDamage(damage);
                        Destroy(this.gameObject);
                    }
                }

                RaycastHit2D hit2DPF = Physics2D.Raycast(transform.position, transform.up, div, playerFriends);
                if (hit2DP.collider != null)
                {

                    if (hit2DP.collider.CompareTag("PlayerFriends"))
                    {

                        hit2DP.collider.GetComponent<PlayerFriendsConroller>().TakeDamage(damage);
                        Destroy(this.gameObject);
                    }
                }


            RaycastHit2D hit2DG = Physics2D.Raycast(transform.position, transform.up, div, stone1);
                if (hit2DG.collider != null)
                {

                    if (hit2DG.collider.CompareTag("Stone"))
                    {   Destroy(this.gameObject);
                        hit2DG.collider.GetComponent<Stone>().Die();
                        
                    }
                }

            RaycastHit2D hit2Db = Physics2D.Raycast(transform.position, transform.up, div, stone1);
            if (hit2Db.collider != null)
            {

                if (hit2Db.collider.CompareTag("BasePlayer"))
                {
                  
                    hit2Db.collider.GetComponent<Stone>().Die();
                    Destroy(this.gameObject);

                }
            }

            RaycastHit2D hit2Dbb = Physics2D.Raycast(transform.position, transform.up, div, stone3);
            if (hit2Dbb.collider != null)
            {

                if (hit2Dbb.collider.CompareTag("BaseEnemy"))
                {
                   
                    hit2Dbb.collider.GetComponent<BaseEnemy>().TakeDamage(damage);
                    Destroy(this.gameObject);

                }
            }

            //}
        }


        void Update()
        {

            if (direction == "left")
            {
                transform.position += new Vector3(speed, 0, 0);
            }
            else if (direction == "right")
            {
                transform.position += new Vector3(-speed, 0, 0);
            }
            else if (direction == "up")
            {
                transform.position += new Vector3(0, speed, 0);
            }
            else if (direction == "down")
            {
                transform.position += new Vector3(0, -speed, 0);
            } 
        }

        void CheckingStone()
        {
            onStone = Physics2D.OverlapCircle(stoneCheck.position, stoneCheckRadius, stone2);
        }
    }
}