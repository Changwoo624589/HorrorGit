using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject menuPanel;

    void Start()
    {
        
    }

    void Update()
    {
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
