using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fadeControl : MonoBehaviour
{
    public GameObject fadePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public  IEnumerator FadeToBlack(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = fadePanel.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while(fadePanel.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadePanel.GetComponent<Image>().color = objectColor;

                yield return null; 
            }
            
        }
        else
        {
            while(fadePanel.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);

                fadePanel.GetComponent<Image>().color = objectColor;

                yield return null;
            }
        }
                          
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadeToBlack()); 
        }
        else
        {
            StartCoroutine(FadeToBlack(false));
        }
    }
}
