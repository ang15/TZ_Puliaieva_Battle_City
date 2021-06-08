using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private GameObject GameOwer;
        private System.Random r = new System.Random();
        [SerializeField] private float speed;
        [SerializeField] private Vector2 moveVelocity;
        [SerializeField] private bool onGround1 = false;
        [SerializeField] private bool onGround2 = false;
        [SerializeField] private LayerMask Ground;
        [SerializeField] private Transform GroundCheck1;
        [SerializeField] private Transform GroundCheck2;
        [SerializeField] private float GroundCheckRadius;
        [SerializeField] private GameObject bullet_obj;
        [SerializeField] private string direction = "up";
        [SerializeField] private int health;
        private int indexBase = 1;
        private int indexTowel = 1;
        private int indexFast = 1;
        private int indexPowerd = 1;
        private GameObject basel;
        private GameObject towell;
        private GameObject fastl;
        private GameObject powerdl;
        [SerializeField] private GameObject baseIg;
        [SerializeField] private GameObject baseIIg;
        [SerializeField] private GameObject baseIIIg;
        [SerializeField] private GameObject towelIg;
        [SerializeField] private GameObject towelIIg;
        [SerializeField] private GameObject towelIIIg;
        [SerializeField] private GameObject fastIg;
        [SerializeField] private GameObject fastIIg;
        [SerializeField] private GameObject fastIIIg;
        [SerializeField] private GameObject powerdIg;
        [SerializeField] private GameObject powerdIIg;
        [SerializeField] private GameObject powerdIIIg;
        [SerializeField] private GameObject tanck;
        private bool buttleM;
        private bool buttleZ;

        public int IndexBase { get => indexBase; set => indexBase = value; }
        public int IndexTowel { get => indexTowel; set => indexTowel = value; }
        public int IndexPowerd { get => indexPowerd; set => indexPowerd = value; }
        public int IndexFast { get => indexFast; set => indexFast = value; }
        public bool ButtleM { get => buttleM; set => buttleM = value; }
        public bool ButtleZ { get => buttleZ; set => buttleZ = value; }

        void Start()
        {
            Time.timeScale = 1f;
            ModelBase();
            ModelFast();
            ModelPowerd();
            ModelTowel();
        }


        void Update()
        {
        
            CheckingGround();

            if (Input.GetKey(KeyCode.M))
            {
                ButtleM = Input.GetKey(KeyCode.M);
            }
            else
            if (Input.GetKey(KeyCode.Z))
            {
                ButtleZ = Input.GetKey(KeyCode.Z);

            }

            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                buttleM = false;
                buttleZ = false;

                if (Input.GetAxis("Horizontal") > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    direction = "left";
                }
                else if (Input.GetAxis("Horizontal") < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    direction = "right";
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    direction = "down";
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    direction = "up";
                }

                if (onGround1 == false && onGround2 == false)
                {
                    Vector3 dir = transform.right * 5;

                    transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed*Time.deltaTime);
                }

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet;
                bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity); ;
                bullet.GetComponent<BulletPlayer>().direction = direction;
                bullet.GetComponent<BulletPlayer>().owner = "player";
                Destroy(bullet, 5f);
            }


            if (health < 1)
            {
                GameOwer.SetActive(true);
                Time.timeScale = 0f;
                Destroy(this.gameObject);
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Die()
        {
            GameOwer.SetActive(true);
            Time.timeScale = 0f;
            Destroy(this.gameObject);
        }


        void CheckingGround()
        {
            onGround1 = Physics2D.OverlapCircle(GroundCheck2.position, GroundCheckRadius, Ground);
            onGround2 = Physics2D.OverlapCircle(GroundCheck1.position, GroundCheckRadius, Ground);

        }
        public void ModelBase()
        {
         
            if (IndexBase == 1)
            {
                basel = baseIg;
                health = 20;
                speed = 1000;
                baseIg.SetActive(true);
                baseIIg.SetActive(false);
                baseIIIg.SetActive(false);
            }

            else if (IndexBase == 2)
            {
                basel = baseIIg;
                health = 40;
                speed = 666;
                baseIg.SetActive(false);
                baseIIg.SetActive(true);
                baseIIIg.SetActive(false);
            }

            else if (IndexBase == 3)
            {
                basel = baseIIIg;
                speed = 500;
                health = 60;
                baseIg.SetActive(false);
                baseIIg.SetActive(false);
                baseIIIg.SetActive(true);
            }

        }


        public void ModelTowel()
        {


            if (IndexTowel == 0)
            {
                towell = null;
                towelIg.SetActive(false);
                towelIIg.SetActive(false);
                towelIIIg.SetActive(false);
            }

            else if (IndexTowel == 1)
            {
                towell = towelIg;
                towelIg.SetActive(true);
                towelIIg.SetActive(false);
                towelIIIg.SetActive(false);
            }

            else if (IndexTowel == 2)
            {
                towell = towelIIg;
                towelIg.SetActive(false);
                towelIIg.SetActive(true);
                towelIIIg.SetActive(false);
            }

            else if (IndexTowel == 3)
            {
                towell = towelIIIg;
                towelIg.SetActive(false);
                towelIIg.SetActive(false);
                towelIIIg.SetActive(true);
            }

        }
        public void ModelFast()
        {

            if (IndexFast == 0)
            {
                fastl = null;
                fastIg.SetActive(false);
                fastIIg.SetActive(false);
                fastIIIg.SetActive(false);
            }

            else if (IndexFast == 1)
            {
                fastl = fastIg;
                fastIg.SetActive(true);
                fastIIg.SetActive(false);
                fastIIIg.SetActive(false);
            }

            else if (IndexFast == 2)
            {
                fastl = fastIIg;
                fastIg.SetActive(false);
                fastIIg.SetActive(true);
                fastIIIg.SetActive(false);
            }

            else if (IndexFast == 3)
            {
                fastl = fastIIIg;
                fastIg.SetActive(false);
                fastIIg.SetActive(false);
                fastIIIg.SetActive(true);
            }

        }
        public void ModelPowerd()
        {

            if (IndexPowerd == 0)
            {
                powerdl = null;
                powerdIg.SetActive(false);
                powerdIIg.SetActive(false);
                powerdIIIg.SetActive(false);
            }

            else if (IndexPowerd == 1)
            {
                powerdl = powerdIg;
                powerdIg.SetActive(true);
                powerdIIg.SetActive(false);
                powerdIIIg.SetActive(false);
            }

            else if (IndexPowerd == 2)
            {
                powerdl = powerdIIg;
                powerdIg.SetActive(false);
                powerdIIg.SetActive(true);
                powerdIIIg.SetActive(false);
            }

            else if (IndexPowerd == 3)
            {
                powerdl = powerdIIIg;
                powerdIg.SetActive(false);
                powerdIIg.SetActive(false);
                powerdIIIg.SetActive(true);
            }

        }
    }
}
