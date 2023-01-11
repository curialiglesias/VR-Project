using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;

    public float interval = 5;
    public float radius = 60f;
    private GameObject Player;
    private Vector3 center;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(interval, enemy));
        Player = GameObject.FindWithTag("Player");
        center = Player.transform.position;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {

        yield return new WaitForSeconds(interval);
        Vector3 pos = RandomCircle(center, radius);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        Instantiate(enemy, pos, rot);
        StartCoroutine(spawnEnemy(interval, enemy));

    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = 20;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
}
