using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject Player;
    private float MaxDist = 100;
    private float MinDist = 1;
    public int enemyDamage = 1;
    public int bulletDamage = 1;
    public int health = 5;
    public float MoveSpeed = 2;
    public float knockbackForce = 250;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z));

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance <= MaxDist && distance >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
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
            Destroy(collision.gameObject,1);
            takeDamage(bulletDamage);
            Debug.Log("Enemy Damage");
            //Knockback
            transform.position -= transform.forward * Time.deltaTime * knockbackForce;
        }
    }

}
