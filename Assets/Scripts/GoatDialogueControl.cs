using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoatDialogueControl : MonoBehaviour
{
    public GameObject dialoguePanel;

    public GameObject dialoguePanel2;

    public GameObject dialoguePanel3; 

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
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            { 
                StartCoroutine(OpenDialogue());
            }
            if(Input.GetKey(KeyCode.Space) && PlayerController.triggerCount >= 1)
            {
                StartCoroutine(OpenSecondaryDialogue());
            }
        }
    }

    IEnumerator OpenDialogue()
    {

        WaitForSeconds waitTime = new WaitForSeconds(1);
        yield return waitTime;
        dialoguePanel.SetActive(true);


        WaitForSeconds waitTime2 = new WaitForSeconds(2);
        yield return waitTime2;
        dialoguePanel.SetActive(false);

    }

    IEnumerator OpenSecondaryDialogue()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1);
        yield return waitTime;
        dialoguePanel2.SetActive(true);

        WaitForSeconds waitTime2 = new WaitForSeconds(3);
        yield return waitTime2;
        dialoguePanel2.SetActive(false);
        dialoguePanel3.SetActive(true); 

        WaitForSeconds waitTime3 = new WaitForSeconds(6);
        yield return waitTime3;
        dialoguePanel3.SetActive(false); 
        
    }

}