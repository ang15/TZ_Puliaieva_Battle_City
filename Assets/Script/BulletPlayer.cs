using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class BulletPlayer : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        public string direction = "left";
        [SerializeField] private float speed;
        [SerializeField] public string owner = "none";

        [SerializeField] private bool onStone = false;
        [SerializeField] private LayerMask stone1;
        [SerializeField] private LayerMask stone2;
        [SerializeField] private LayerMask stone3;
        [SerializeField] private Transform stoneCheck;
        [SerializeField] private float stoneCheckRadius;

        //[SerializeField] private LayerMask player;
        //[SerializeField] private LayerMask playerFriends;
        [SerializeField] private LayerMask  enemy;


        private float div=10f;

        public int Damage { get => damage; set => damage = value; }

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

            RaycastHit2D hit2DE = Physics2D.Raycast(transform.position, transform.up, div, enemy);
            if (hit2DE.collider != null)
            {
                if (hit2DE.collider.CompareTag("Enemy"))
                {
                    hit2DE.collider.GetComponent<Enemy>().TakeDamage(Damage);
                    Destroy(this.gameObject);
                }
            }



            RaycastHit2D hit2DG = Physics2D.Raycast(transform.position, transform.up, div, stone1);
            if (hit2DG.collider != null)
            {

                if (hit2DG.collider.CompareTag("Stone"))
                {
                    hit2DG.collider.GetComponent<Stone>().Die();
                    Destroy(this.gameObject);
                }
            }

            RaycastHit2D hit2DB = Physics2D.Raycast(transform.position, transform.up, div, stone1);
            if (hit2DG.collider != null)
            {

                if (hit2DG.collider.CompareTag("BaseEnemy"))
                {
                    hit2DG.collider.GetComponent<Stone>().Die();
                    Destroy(this.gameObject);
                }
            }

            RaycastHit2D hit2Db = Physics2D.Raycast(transform.position, transform.up, div,stone3);
            if (hit2Db.collider != null)
            {

                if (hit2Db.collider.CompareTag("BaseEnemy"))
                {
                    hit2Db.collider.GetComponent<BaseEnemy>().TakeDamage(Damage);
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