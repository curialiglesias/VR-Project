using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private GameObject Player;
    private float MaxDist = 100;
    private float MinDist = 1;

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
            Debug.Log(transform.position);
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

}
