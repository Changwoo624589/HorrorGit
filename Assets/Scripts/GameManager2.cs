using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    private GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
      
        gm.enabled = true;
       
    }
    void Start()
    {
        GameManager.Instance.darkMode = false;
        GameManager.Instance.start = true;
        Debug.Log("Start");

    }

    void Update()
    {
        
    }
}
