using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject pausePanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
           // pausePanel.SetActive(true);
            GameManager.Instance.Pause();
            
        }
        if (GameManager.Instance.pause)
        {
            pausePanel.SetActive(true);
        }
        else { pausePanel.SetActive(false); }
    }
}
