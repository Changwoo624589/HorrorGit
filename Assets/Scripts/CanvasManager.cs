using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject optionPanel;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            // pausePanel.SetActive(true);
            if (!GameManager.Instance.option) {   GameManager.Instance.Pause();  }
            else { GameManager.Instance.Option(); }

        }
        if (GameManager.Instance.pause && !GameManager.Instance.option)
        {
            pausePanel.SetActive(true);
        }
        else { pausePanel.SetActive(false); }
        if (GameManager.Instance.option)
        {
            optionPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
        else {
            optionPanel.SetActive(false);
        }
        
    }
}
