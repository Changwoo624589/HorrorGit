using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public GameObject creditPanel;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.credit)
        {
            creditPanel.SetActive(true);
        }
        else { creditPanel.SetActive(false); }
    }
}
