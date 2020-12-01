using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;
    Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 doorToPlayer = player.position - tr.position;
        float dotProduct = Vector3.Dot(transform.up, doorToPlayer);
        Debug.Log(dotProduct);
    }
}
