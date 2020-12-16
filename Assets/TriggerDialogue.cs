using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TriggerDialogue : MonoBehaviour
{
    public GameObject dialoguePanel;



    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "CanTalkWith")
        {
            if (Input.GetKey(KeyCode.Space))
            {
               
                StartCoroutine(OpenDialogue()); 
            }
        }
    }

    IEnumerator OpenDialogue()
    {

        WaitForSeconds waitTime = new WaitForSeconds(1); 
        yield return waitTime;
        dialoguePanel.SetActive(true);
        

        WaitForSeconds waitTime2 = new WaitForSeconds(5);
       yield return waitTime2;
        dialoguePanel.SetActive(false);
        

    }

}


    
