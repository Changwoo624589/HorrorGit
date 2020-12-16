using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStart : MonoBehaviour
{
    public GameObject optionStart;
    public GameObject creditPanel;
    public GameObject menuPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.option2)
        {
            optionStart.SetActive(true);
        }
        else {
            optionStart.SetActive(false);
        }
       
        if (GameManager.Instance.start)
        {
            menuPanel.SetActive(false);
        }
        else { menuPanel.SetActive(true); }
        
        if (GameManager.Instance.credit)
        {
            creditPanel.SetActive(true);
        }
        else
        {
            creditPanel.SetActive(false);
        }
    }
}
