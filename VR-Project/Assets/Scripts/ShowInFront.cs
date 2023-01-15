using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInFront : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        transform.LookAt(head);
        transform.forward *= -1;
    }
}
