using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public GameObject GameOverPanel;
    public GameObject RestartingSystem;
    [HideInInspector]
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Hit");
        if (health <= 0 && isDead == false)
        {
            isDead = true;
            Debug.Log("You are dead");
            GameObject.Find("pistol R").SetActive(false);
            GameObject.Find("pistol L").SetActive(false);
            GameObject.Find("Spawn").SetActive(false);
            GameOverPanel.SetActive(true);
            RestartingSystem.SetActive(true);
        }
    }
}
