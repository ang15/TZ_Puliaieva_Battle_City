using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class PlayerFriendsConroller : MonoBehaviour
    {

        private System.Random r = new System.Random();

        [SerializeField] private string direction = "down";
        private int direct;
        [SerializeField] private bool onGround1 = false;
        [SerializeField] private bool onGround2 = false;
        [SerializeField] private LayerMask Ground;
        [SerializeField] private Transform GroundCheck1;
        [SerializeField] private Transform GroundCheck2;
        [SerializeField] private float GroundCheckRadius;
        [SerializeField] private GameObject bullet_obj;
        [SerializeField] private float speed;
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
        [SerializeField] private int health = 20;
        public Transform point;
        private float timeBullet;
        [SerializeField] private float starttimeBullet;
  
        private int directs = 4;
        private BoxCollider2D _boxColleder;
        private bool die1 = true;
        public float div = 12f;
        [SerializeField] private LayerMask gamer;
        [SerializeField]private BasePlayer basePlayer;

        
        public int IndexBase { get => indexBase; set => indexBase = value; }
        public int IndexTowel { get => indexTowel; set => indexTowel = value; }
        public int IndexFast { get => indexFast; set => indexFast = value; }
        public int IndexPowerd { get => indexPowerd; set => indexPowerd = value; }
        public int Models { get; private set; }
        public bool Die1 { get => die1; set => die1 = value; }
        public int GamePlayer { get;  set; }

        void Start()
        {
            ModelBase();
            ModelFast();
            ModelPowerd();
            ModelTowel();
            _boxColleder = GetComponent<BoxCollider2D>();
            timeBullet = starttimeBullet;
            direct = r.Next(1, 5);
            if (direct == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
                direction = "left";
            }
            else
              if (direct == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                direction = "right";
            }
            else
              if (direct == 3)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                direction = "down";
            }
            else
             if (direct == 4)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                direction = "up";
            }
        }

        void Update()
        {
            //DieNumber = GamePlayer - 2;
            if (Die1)
            {
                _boxColleder.isTrigger = true;
                CheckingGround();
                if (direct == 1)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                    direction = "left";
                }
                else
                 if (direct == 2)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    direction = "right";
                }
                else
                 if (direct == 3)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                    direction = "down";
                }
                else
                if (direct == 4)
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                    direction = "up";
                }



                if (timeBullet <= 0)
                {

                    GameObject bullet;
                    bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity);
                    bullet.GetComponent<BulletPlayer>().direction = direction;
                    bullet.GetComponent<BulletPlayer>().owner = "PlayerFriends";
                    Destroy(bullet, 5f);
                    timeBullet = starttimeBullet;
                }
                else
                {
                    timeBullet -= Time.deltaTime;
                }

                if ((onGround1 || onGround2) || (onGround1 && onGround2))
                {
                    if (direct == 1)
                    {
                        direct = r.Next(1, 5);
                    }
                    else
                    if (direct == 2)
                    {
                        direct = r.Next(1, 5);
                    }
                    else
                    if (direct == 3)
                    {
                        direct = r.Next(1, 5);

                    }
                    else
                    if (direct == 4)
                    {
                        direct = direct = r.Next(1, 5);

                    }
                }

                if (onGround1 == false && onGround2 == false)
                {
                    Vector3 dir = transform.right * 5;

                    transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed);
                }

                if (health < 1)
                {
                    Die();
                }
            }
            if (Die1 == false)
            {
                
                Model();
            }
        }

        void Model()
        {

            if (Models == 1)
            {
                RaycastHit2D hit2DP = Physics2D.Raycast(transform.position, transform.up, div, gamer);
                if (hit2DP.collider != null)
                {
                    if (hit2DP.collider.CompareTag("Player"))
                    {
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleM == true)
                        {
                            if (IndexBase >= hit2DP.collider.GetComponent<PlayerController>().IndexBase && IndexBase == 4)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexBase = IndexBase;
                                hit2DP.collider.GetComponent<PlayerController>().ModelBase();
                                Destroy(this.gameObject);
                            }
                            else
                            if (IndexBase >= hit2DP.collider.GetComponent<PlayerController>().IndexBase)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexBase = IndexBase + 1;
                                hit2DP.collider.GetComponent<PlayerController>().ModelBase();
                                Destroy(this.gameObject);
                            }
                            hit2DP.collider.GetComponent<PlayerController>().ButtleM = false;
                        }
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleZ == true)
                        {
                            hit2DP.collider.GetComponent<PlayerController>().ButtleZ = false;
                            Destroy(this.gameObject);
                        }
                    }
                    else
                    if (hit2DP.collider.CompareTag("PlayerFriends"))
                    {
                        if (IndexBase >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexBase && IndexBase == 4)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexBase = IndexBase ;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelBase();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexBase >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexBase)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexBase = IndexBase+1;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelBase();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexBase < hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexBase)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                     if (hit2DP.collider.CompareTag("Enemy"))
                {

                    if (IndexBase >= hit2DP.collider.GetComponent<Enemy>().IndexBase && IndexBase == 4)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexBase = IndexBase;
                        hit2DP.collider.GetComponent<Enemy>().ModelBase();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexBase >= hit2DP.collider.GetComponent<Enemy>().IndexBase)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexBase = IndexBase + 1;
                        hit2DP.collider.GetComponent<Enemy>().ModelBase();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexBase < hit2DP.collider.GetComponent<Enemy>().IndexBase)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            if (Models == 2)
            {
                RaycastHit2D hit2DP = Physics2D.Raycast(transform.position, transform.up, div, gamer);
                if (hit2DP.collider != null)
                {
                    if (hit2DP.collider.CompareTag("Player"))
                    {
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleM == true)
                        {
                            if (IndexTowel >= hit2DP.collider.GetComponent<PlayerController>().IndexTowel && IndexTowel == 4)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexTowel = IndexTowel;
                                hit2DP.collider.GetComponent<PlayerController>().ModelTowel();
                                Destroy(this.gameObject);
                            }
                            else
                            if (IndexTowel >= hit2DP.collider.GetComponent<PlayerController>().IndexTowel)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexTowel = IndexTowel + 1;
                                hit2DP.collider.GetComponent<PlayerController>().ModelTowel();
                                Destroy(this.gameObject);
                            }
                            hit2DP.collider.GetComponent<PlayerController>().ButtleM = false;
                        }
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleZ == true)
                        {
                            hit2DP.collider.GetComponent<PlayerController>().ButtleZ = false;
                            Destroy(this.gameObject);
                        }
                    }
                    else
                                       if (hit2DP.collider.CompareTag("PlayerFriends"))
                    {
                        if (IndexTowel >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexTowel && IndexTowel == 4)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexTowel = IndexTowel;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelTowel();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexTowel >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexTowel)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexTowel = IndexTowel + 1;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelTowel();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexTowel < hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexTowel)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                     if (hit2DP.collider.CompareTag("Enemy"))
                {

                    if (IndexTowel >= hit2DP.collider.GetComponent<Enemy>().IndexTowel && IndexTowel == 4)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexTowel = IndexTowel;
                        hit2DP.collider.GetComponent<Enemy>().ModelTowel();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexTowel >= hit2DP.collider.GetComponent<Enemy>().IndexTowel)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexTowel = IndexTowel + 1;
                        hit2DP.collider.GetComponent<Enemy>().ModelTowel();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexTowel < hit2DP.collider.GetComponent<Enemy>().IndexTowel)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            if (Models == 3)
            {
                RaycastHit2D hit2DP = Physics2D.Raycast(transform.position, transform.up, div, gamer);
                if (hit2DP.collider != null)
                {
                    if (hit2DP.collider.CompareTag("Player"))
                    {
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleM == true)
                        {
                            if (IndexPowerd >= hit2DP.collider.GetComponent<PlayerController>().IndexPowerd && IndexPowerd == 4)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexPowerd = IndexPowerd;
                                hit2DP.collider.GetComponent<PlayerController>().ModelPowerd();
                                Destroy(this.gameObject);
                            }
                            else
                            if (IndexPowerd >= hit2DP.collider.GetComponent<PlayerController>().IndexPowerd)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexPowerd = IndexPowerd + 1;
                                hit2DP.collider.GetComponent<PlayerController>().ModelPowerd();
                                Destroy(this.gameObject);
                            }
                            hit2DP.collider.GetComponent<PlayerController>().ButtleM = false;
                        }
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleZ == true)
                        {
                            hit2DP.collider.GetComponent<PlayerController>().ButtleZ = false;
                            Destroy(this.gameObject);
                        }
                    }
                    else
                    if (hit2DP.collider.CompareTag("PlayerFriends"))
                    {
                        if (IndexPowerd >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexPowerd && IndexPowerd == 4)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexPowerd = IndexPowerd;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelPowerd();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexPowerd >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexPowerd)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexPowerd = IndexPowerd + 1;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelPowerd();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexPowerd < hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexPowerd)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                     if (hit2DP.collider.CompareTag("Enemy"))
                {

                    if (IndexPowerd >= hit2DP.collider.GetComponent<Enemy>().IndexPowerd && IndexPowerd == 4)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexPowerd = IndexPowerd;
                        hit2DP.collider.GetComponent<Enemy>().ModelPowerd();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexPowerd >= hit2DP.collider.GetComponent<Enemy>().IndexPowerd)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexPowerd = IndexPowerd + 1;
                        hit2DP.collider.GetComponent<Enemy>().ModelPowerd();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexPowerd < hit2DP.collider.GetComponent<Enemy>().IndexPowerd)
                    {
                        Destroy(this.gameObject);
                    }
                }
            }
            if (Models == 4)
            {
                RaycastHit2D hit2DP = Physics2D.Raycast(transform.position, transform.up, div, gamer);
                if (hit2DP.collider != null)
                {
                    if (hit2DP.collider.CompareTag("Player"))
                    {
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleM == true)
                        {
                            if (IndexFast >= hit2DP.collider.GetComponent<PlayerController>().IndexFast && IndexFast == 4)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexFast = IndexFast;
                                hit2DP.collider.GetComponent<PlayerController>().ModelFast();
                                Destroy(this.gameObject);
                            }
                            else
                            if (IndexFast >= hit2DP.collider.GetComponent<PlayerController>().IndexFast)
                            {

                                hit2DP.collider.GetComponent<PlayerController>().IndexFast = IndexFast + 1;
                                hit2DP.collider.GetComponent<PlayerController>().ModelFast();
                                Destroy(this.gameObject);
                            }
                            hit2DP.collider.GetComponent<PlayerController>().ButtleM = false;
                        }
                        if (hit2DP.collider.GetComponent<PlayerController>().ButtleZ == true)
                        {
                            hit2DP.collider.GetComponent<PlayerController>().ButtleZ = false;
                            Destroy(this.gameObject);
                        }
                    }
                    else
                     if (hit2DP.collider.CompareTag("PlayerFriends"))
                    {
                        if (IndexFast >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexFast && IndexFast == 4)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexFast = IndexFast;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelFast();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexFast >= hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexFast)
                        {
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexFast = IndexFast + 1;
                            hit2DP.collider.GetComponent<PlayerFriendsConroller>().ModelFast();
                            Destroy(this.gameObject);
                        }
                        else
                        if (IndexFast < hit2DP.collider.GetComponent<PlayerFriendsConroller>().IndexFast)
                        {
                            Destroy(this.gameObject);
                        }
                    }
                }
                else
                     if (hit2DP.collider.CompareTag("Enemy"))
                {

                    if (IndexFast >= hit2DP.collider.GetComponent<Enemy>().IndexFast && IndexFast == 4)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexFast = IndexFast;
                        hit2DP.collider.GetComponent<Enemy>().ModelFast();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexFast >= hit2DP.collider.GetComponent<Enemy>().IndexFast)
                    {
                        hit2DP.collider.GetComponent<Enemy>().IndexFast = IndexFast + 1;
                        hit2DP.collider.GetComponent<Enemy>().ModelFast();
                        Destroy(this.gameObject);
                    }
                    else
                       if (IndexFast < hit2DP.collider.GetComponent<Enemy>().IndexFast)
                    {
                        Destroy(this.gameObject);
                    }
                }

            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        public void Die()
        {
           
            basePlayer.Gamer(GamePlayer);
            _boxColleder.isTrigger = true;
            gameObject.layer = 16;
            Die1 = false;
            directs = r.Next(1, 5);
            if (directs == 1)
            {
                Models = 3;
                IndexBase = 0;
                IndexTowel = 0;
                IndexFast = 0;
                ModelFast();
                ModelTowel();
                ModelBase();
            }
            if (directs == 2)
            {
                Models = 4;
                IndexBase = 0;
                IndexTowel = 0;
                IndexPowerd = 0;
                ModelPowerd();
                ModelTowel();
                ModelBase();
            }
            if (directs == 3)
            {
                Models = 1;
                IndexPowerd = 0;
                IndexTowel = 0;
                IndexFast = 0;
                ModelPowerd();
                ModelTowel();
                ModelFast();

            }
            if (directs == 4)
            {
                Models = 2;
                IndexBase = 0;
                IndexPowerd = 0;
                IndexFast = 0;
                ModelFast();
                ModelPowerd();
                ModelBase();
            }
            tanck.SetActive(false);
        }


        public void CheckingGround()
        {
            onGround1 = Physics2D.OverlapCircle(GroundCheck1.position, GroundCheckRadius, Ground);
            onGround2 = Physics2D.OverlapCircle(GroundCheck2.position, GroundCheckRadius, Ground);
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
                baseIIg.SetActive(true);
                baseIIIg.SetActive(false);
            }

        }
        public void ModelTowel()
        {

            if (IndexTowel == 1)
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

            if (IndexFast == 1)
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

            if (IndexPowerd == 1)
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
