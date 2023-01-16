using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    private int kills = 0;
    public TMP_Text killsCounterText;
    public TMP_Text enemiesKilledText;

    void Start()
    {
        kills = 0;
    }

    public void addKill()
    {
        kills += 1;
        killsCounterText.text = kills.ToString() + " KILLS";
        enemiesKilledText.text = "Enemies killed:  " + kills;
        Debug.Log(killsCounterText.text);
    }
}
