using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public playerLife playerHealth;
    private GameObject Player;
    private float MaxDist = 100;
    private float MinDist = 1;
    public int damage = 1;
    public float health = 10f;
    public float MoveSpeed = 2;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        transform.LookAt(Player.transform);

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance <= MaxDist && distance >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.takeDamage(damage);
        }
    }

}
