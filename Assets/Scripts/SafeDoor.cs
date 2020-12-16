using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class SafeDoor : MonoBehaviour
{
    private AudioSource aud;
    public SafeDoorPW [] pws;
    private Animator ani;
    public bool unlocked;
    
    void Start()
    {
        
        unlocked = false;
        foreach (SafeDoorPW pw in pws) {
           pw.GetComponent<SafeDoorPW>();
        }
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Debug.Log(pws[0].pw);
        if (
        pws[0].pw ==6 &&
        pws[1].pw ==2 &&
        pws[2].pw ==4 
        ) 
        {
            if (!unlocked)
            {
                StartCoroutine(DoorIsUnlocked());
            }
            unlocked = true; 
        }


    }
    IEnumerator DoorIsUnlocked() 
    {
        aud.Play();
        yield return new WaitForSeconds(0.9f);
       
        ani = GetComponent<Animator>();
        ani.SetTrigger("OpenSB");
    }
}
