using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastDoor : MonoBehaviour
{
    public GameObject endCol;
    private Door door;
    void Start()
    {
        door = GetComponent<Door>();
    }

    void Update()
    {
        if (door.isOpened) {
            endCol.SetActive(true);
            GameManager.Instance.darkMode = true;
        }   
    }
}
