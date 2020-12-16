using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LastDoor : MonoBehaviour
{
    public GameObject endCol;
    private Door door;

    public Transform finalDestination;
    public Transform host;

    public SpriteRenderer sr;

    public Sprite goodbear;
    public Sprite badbear;

    public GameObject finalPanel;
    public GameObject finalPanel2;

    void Start()
    {
        door = GetComponent<Door>();
    }

    void Update()
    {
        if(sr.sprite == null)
        {
            sr.sprite = goodbear;
        }

        finalDestination = GameObject.Find("FinalDestination").transform;
        host = GameObject.Find("Host").transform; 

        if (door.isOpened) {
            endCol.SetActive(true);
            GameManager.Instance.darkMode = true;

            host.transform.position = finalDestination.position;
            sr.sprite = badbear;

            StartCoroutine(FinalDialogue());

        }  
        

     
    }
    IEnumerator FinalDialogue()
    {
        WaitForSeconds waitTime = new WaitForSeconds(1);
        yield return waitTime;
        finalPanel.SetActive(true);

        WaitForSeconds waitTime2 = new WaitForSeconds(4);
        yield return waitTime2;
        finalPanel.SetActive(false);
        finalPanel2.SetActive(true);

        WaitForSeconds waitTime3 = new WaitForSeconds(5);
        yield return waitTime3;
        finalPanel2.SetActive(false); 
        
    }
}
