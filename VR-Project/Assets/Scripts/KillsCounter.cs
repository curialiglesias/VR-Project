using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillsCounter : MonoBehaviour
{
    [HideInInspector]
    public int kills = -1;
    private TMP_Text tmp;

    // Start is called before the first frame update
    void Start()
    {
        kills = -1;
        tmp = GetComponent<TextMeshPro>();
        addKill();
    }

    public void addKill()
    {
        kills += 1;
        tmp.text = kills.ToString() + " KILLS";
        Debug.Log(tmp.text);
    }
}
