using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{

    public GameObject fadePanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {

            StartCoroutine(FadeToBlack());
          
            SceneManager.LoadScene(1);

            
        }
    
    }

    public IEnumerator FadeToBlack(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color objectColor = fadePanel.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (fadePanel.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadePanel.GetComponent<Image>().color = objectColor;

                yield return null;
            }

        }
        else
        {
            while (fadePanel.GetComponent<Image>().color.a > 0)
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
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(FadeToBlack());
        }
        else
        {
            StartCoroutine(FadeToBlack(false));
        }
    }
}

