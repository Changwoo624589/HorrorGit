using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostDialogueControl : MonoBehaviour
{
    public GameObject dialoguePanel;

    public GameObject dialoguePanel2;

    public Transform destination;

    

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
        }
    }

    IEnumerator OpenDialogue()
    {
        float speed = 10; 
        float step = speed * Time.deltaTime;

        WaitForSeconds waitTime = new WaitForSeconds(1);
        yield return waitTime;
        dialoguePanel.SetActive(true);


        WaitForSeconds waitTime2 = new WaitForSeconds(3);
        yield return waitTime2;
        dialoguePanel.SetActive(false);
        dialoguePanel2.SetActive(true);

        WaitForSeconds waitTime3 = new WaitForSeconds(5);
        yield return waitTime3;
        dialoguePanel2.SetActive(false);

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.position, step);



    }

}