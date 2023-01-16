using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    private GameObject Player;
    private playerLife playerLife;
    private GameObject KillsCounterObject;
    private KillsCounter KillsCounter;
    private float MaxDist = 100;
    private float MinDist = 1;
    public int enemyDamage = 1;
    public int bulletDamage = 1;
    public int health = 5;
    public float MoveSpeed = 2;
    public float knockbackForce = 250;
    private Animator animator;
    private bool isDead = false;
    private Rigidbody rb;
    public GameObject bloodEffect;
    private bool isDancing = false;
    private float timeColliding = 0f;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerLife = Player.GetComponent<playerLife>();
        KillsCounterObject = GameObject.FindWithTag("KillsCounter");
        KillsCounter = KillsCounterObject.GetComponent<KillsCounter>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDancing = false;
        timeColliding = 0f;

    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (playerLife.isDead)
            {
                if (isDancing == false)
                {
                    animator.SetBool("isDancing", true);
                    isDancing = true;
                }
            }
            else
            {
                animator.SetBool("isDancing", false);
                isDancing = false;

                transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));

                float distance = Vector3.Distance(transform.position, Player.transform.position);

                if (distance <= MaxDist && distance >= MinDist)
                {
                    transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                }

                if (distance <= 5)
                {
                    animator.SetBool("isAttacking", true);
                    animator.SetBool("isMoving", false);
                }
                else
                {
                    animator.SetBool("isMoving", true);
                    animator.SetBool("isAttacking", false);
                }
            }
        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("isDying");
            Destroy(gameObject,5);
            KillsCounterObject.GetComponent<KillsCounter>().addKill();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<playerLife>().takeDamage(enemyDamage);
            timeColliding = 0f;
        }

        if (collision.gameObject.tag == "Bullet")
        {
            (collision.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(collision.gameObject,0.5f);

            if (!isDead)
            {
                takeDamage(bulletDamage);

                //Knockback
                transform.position -= transform.forward * Time.deltaTime * knockbackForce;

                // Blood Particles
                var newBlood = Instantiate(bloodEffect, collision.gameObject.transform.position, Quaternion.identity);
                newBlood.transform.LookAt(Player.transform);
                newBlood.transform.position = new Vector3(newBlood.transform.position.x, newBlood.transform.position.y, newBlood.transform.position.z);
                newBlood.transform.parent = gameObject.transform;
                Destroy(newBlood.gameObject, 1f);
            }
            

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (timeColliding < 1)
            {
                timeColliding += Time.deltaTime;
            }
            else
            {
                Player.GetComponent<playerLife>().takeDamage(enemyDamage);
                timeColliding = 0f;
            }
        }

    }

}
