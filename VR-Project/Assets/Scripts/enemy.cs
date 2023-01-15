using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    private GameObject Player;
    private playerLife playerLife;
    private GameObject KillsCounterText;
    private KillsCounter killsCounter;
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
    private Vector3 lastPosition;
    private Vector3 lastRotation;
    public GameObject bloodEffect;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerLife = Player.GetComponent<playerLife>();
        KillsCounterText = GameObject.FindWithTag("KillsCounter");
        killsCounter = KillsCounterText.GetComponent<KillsCounter>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            if (playerLife.isDead)
            {
                animator.SetTrigger("isDancing");
            }
            else
            {
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
            killsCounter.addKill();
            Debug.Log("Enemy dead");
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<playerLife>().takeDamage(enemyDamage);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            (collision.gameObject.GetComponent(typeof(Collider)) as Collider).isTrigger = true;
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Destroy(collision.gameObject,0.5f);

            if (!isDead)
            {
                takeDamage(bulletDamage);
                Debug.Log("Enemy Damage");
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

}
