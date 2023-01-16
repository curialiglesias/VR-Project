using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    [HideInInspector]
    public int kills = 0;
    private TMP_Text tmp;
    public TMP_Text enemiesKilledText;

    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        kills = 0;
    }

    public void addKill()
    {
        kills += 1;
        tmp.text = kills.ToString() + " KILLS";
        enemiesKilledText.text = "Enemies killed:  " + kills;
        Debug.Log(tmp.text);
    }
}
