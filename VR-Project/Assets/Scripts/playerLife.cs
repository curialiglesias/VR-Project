using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{

    public int maxHealth;
    public int health;
    public GameObject GameOverPanel;
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
        if (health <= 0 && isDead == false)
        {
            isDead = true;
            Debug.Log("You are dead");
            GameObject.Find("pistol R").SetActive(false);
            GameObject.Find("pistol L").SetActive(false);
            GameObject.Find("Spawn").SetActive(false);
            GameOverPanel.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
