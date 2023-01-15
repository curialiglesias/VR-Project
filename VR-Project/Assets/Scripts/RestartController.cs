using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartController : MonoBehaviour
{
    public float restartTime = 20;
    public TMP_Text restartingInText;

    void Update()
    {
        restartTime -= Time.deltaTime;
        restartingInText.text = "Restarting in:  " + (int)restartTime;

        if (restartTime <= 0)
        {
            Debug.Log("Restarting game");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
