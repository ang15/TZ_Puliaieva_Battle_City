using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class EnemyBase : MonoBehaviour
    {

        private string direction = "up";
        //private float changeDirectionTime;
        [SerializeField] private int directionNumber;
        //private float shootingRate;
        [SerializeField] private Transform baseE;
        [SerializeField] private bool onGround1 = false;
        [SerializeField] private bool onGround2 = false;
        [SerializeField] private LayerMask Ground;
        [SerializeField] private Transform GroundCheck1;
        [SerializeField] private Transform GroundCheck2;
        [SerializeField] private float GroundCheckRadius;
        [SerializeField] private GameObject bullet_obj;
        [SerializeField] private float speed;
        [SerializeField] private Vector3 currentPos;
        [SerializeField] private int health = 20;

        private bool chill = true;
        private bool angry = false;
        private bool goBack = false;

        [SerializeField] private float stoppingDistance = 1236;
        [SerializeField] private Transform point;
        [SerializeField] private Transform player;
        [SerializeField] private int positionOfPoint;
        [SerializeField] private float dist;
      //  private float div = 12f;
        private float timeBullet;
        [SerializeField] private float starttimeBullet;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;
        private Vector3 positionEnemy;
        public int Health { get => health; set => health = value; }

        void Start()
        {
            transform.position = point.position;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            timeBullet = starttimeBullet;
        }


        void Update()
        {



            dist = Vector2.Distance(baseE.position, player.position);

            CheckingGround();
            if (Vector2.Distance(baseE.position, player.position)> stoppingDistance)
            {
                chill = true;
                angry = false;

            }
            else
            if (Vector2.Distance(baseE.position, player.position) < stoppingDistance)
            {
                angry = true;
                chill = false;
            }
            else
            if (Vector2.Distance(baseE.position, player.position) > stoppingDistance)
            {
                goBack = true;
                angry = false;
                chill = false;
            }

            if (Health < 1)
            {
                Die();
            }

            if (chill == true)
            {
                Chill();
            }
            else
            if (angry == true)
            {
                Angry();
            }
            else if (goBack == true)
            {

            }

        }

        private void GoBack()
        {
            if ((onGround1 && onGround2) || (onGround1 || onGround2))
            {

                Angry();

            }

            if (onGround1 == false && onGround2 == false)
            {


                if (transform.position.x - point.position.x < 1000 && transform.position.x - point.position.x > -1000)
                {
                    directionNumber = 2;
                    if (timeBullet <= 0)
                    {

                        GameObject bullet;
                        bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity);
                        bullet.GetComponent<BulletEnemy>().direction = direction;
                        bullet.GetComponent<BulletEnemy>().owner = "enemy";
                        Destroy(bullet, 5f);
                        timeBullet = starttimeBullet;
                    }
                    else
                    {
                        timeBullet -= Time.deltaTime;
                    }


                }
                if (transform.position.y - point.position.y < 1000 && transform.position.y - point.position.y > -1000)
                {
                    directionNumber = 1;
                    if (timeBullet <= 0)
                    {

                        GameObject bullet;
                        bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity);
                        bullet.GetComponent<BulletEnemy>().direction = direction;
                        bullet.GetComponent<BulletEnemy>().owner = "enemy";
                        Destroy(bullet, 5f);
                        timeBullet = starttimeBullet;
                    }
                    else
                    {
                        timeBullet -= Time.deltaTime;
                    }


                }


                if (directionNumber == 1)
                {
                    if (transform.position.x > point.position.x)
                    {
                        direction = "left";
                        _rigidbody2D.velocity = new Vector2(0, 10f);
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                        positionEnemy = new Vector3(transform.position.x - point.position.x, transform.position.y, transform.position.z);
                    }
                    else if (transform.position.x < point.position.x)
                    {
                        direction = "rigth";

                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        _rigidbody2D.velocity = new Vector2(0, -10f);
                        positionEnemy = new Vector3(transform.position.x + point.position.x, transform.position.y, transform.position.z);
                    }
                }
                else if (directionNumber == 2)
                {
                    if (transform.position.y > point.position.y)
                    {
                        direction = "down";
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        _rigidbody2D.velocity = new Vector2(10f, 0);
                        positionEnemy = new Vector3(transform.position.x, transform.position.y - point.position.y, transform.position.z);
                    }
                    else if (transform.position.y < point.position.y)
                    {
                        direction = "up";
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                        _rigidbody2D.velocity = new Vector2(-10f, 0);
                        positionEnemy = new Vector3(transform.position.x, transform.position.y + point.position.y, transform.position.z);
                    }
                }

                //transform.position = new Vector3(transform.position.x - point.position.x, transform.position.y - point.position.y,0);
                //Vector3 dir = point.position.x * 5;
                transform.position = Vector3.MoveTowards(transform.position, positionEnemy, speed * Time.deltaTime);
            }
        }


        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        void CheckingGround()
        {
            onGround1 = Physics2D.OverlapCircle(GroundCheck1.position, GroundCheckRadius, Ground);
            onGround2 = Physics2D.OverlapCircle(GroundCheck2.position, GroundCheckRadius, Ground);
        }


        void Chill()
        {
            if (transform.position.x <= point.position.x)
            {
                direction = "left";
                //_rigidbody2D.velocity = new Vector2(0, 10f);
                transform.rotation = Quaternion.Euler(0, 0, 180);
                if (onGround1 == false && onGround2 == false)
                {
                    Vector3 dir = transform.right * 5;

                    transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed);
                }

            }else
            if (transform.position.x > point.position.x + positionOfPoint)
            {
                direction = "right";
               // _rigidbody2D.velocity = new Vector2(0, -10f);

                transform.rotation = Quaternion.Euler(0, 0, 0);
                if (onGround1 == false && onGround2 == false)
                {
                    Vector3 dir = transform.right * 5;

                    transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, speed);
                }

            }

        }



        void Angry()
        {

            if ((onGround1 && onGround2) || (onGround1 || onGround2))
            {
                GoBack();

            }

            if (onGround1 == false && onGround2 == false)
            {


                if (transform.position.x - player.position.x < 1000 && transform.position.x - player.position.x > -1000)
                {
                    directionNumber = 2;
                    if (timeBullet <= 0)
                    {

                        GameObject bullet;
                        bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity);
                        bullet.GetComponent<BulletEnemy>().direction = direction;
                        bullet.GetComponent<BulletEnemy>().owner = "enemy";
                        Destroy(bullet, 5f);
                        timeBullet = starttimeBullet;
                    }
                    else
                    {
                        timeBullet -= Time.deltaTime;
                    }


                }
                if (transform.position.y - player.position.y < 1000 && transform.position.y - player.position.y > -1000)
                {
                    directionNumber = 1;
                    if (timeBullet <= 0)
                    {

                        GameObject bullet;
                        bullet = Instantiate(bullet_obj, GetComponent<Transform>().position, Quaternion.identity);
                        bullet.GetComponent<BulletEnemy>().direction = direction;
                        bullet.GetComponent<BulletEnemy>().owner = "enemy";
                        Destroy(bullet, 5f);
                        timeBullet = starttimeBullet;
                    }
                    else
                    {
                        timeBullet -= Time.deltaTime;
                    }


                }


                if (directionNumber == 1)
                {
                    if (transform.position.x > player.position.x)
                    {
                        direction = "left";
                        _rigidbody2D.velocity = new Vector2(0, 10f);
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                        positionEnemy = new Vector3(transform.position.x - player.position.x, transform.position.y, transform.position.z);
                    }
                    else if (transform.position.x < player.position.x)
                    {
                        direction = "rigth";

                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        _rigidbody2D.velocity = new Vector2(0, -10f);
                        positionEnemy = new Vector3(transform.position.x + player.position.x, transform.position.y, transform.position.z);
                    }
                }
                else if (directionNumber == 2)
                {
                    if (transform.position.y > player.position.y)
                    {
                        direction = "down";
                        transform.rotation = Quaternion.Euler(0, 0, 90);
                        _rigidbody2D.velocity = new Vector2(10f, 0);
                        positionEnemy = new Vector3(transform.position.x, transform.position.y - player.position.y, transform.position.z);
                    }
                    else if (transform.position.y < player.position.y)
                    {
                        direction = "up";
                        transform.rotation = Quaternion.Euler(0, 0, -90);
                        _rigidbody2D.velocity = new Vector2(-10f, 0);
                        positionEnemy = new Vector3(transform.position.x, transform.position.y + player.position.y, transform.position.z);
                    }
                }

                //transform.position = new Vector3(transform.position.x - player.position.x, transform.position.y - player.position.y,0);
                //Vector3 dir = player.position.x * 5;
                transform.position = Vector3.MoveTowards(transform.position, positionEnemy, speed * Time.deltaTime);
            }

        }
    }
}