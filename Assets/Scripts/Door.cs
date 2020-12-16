using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Door : MonoBehaviour
{
    public Transform player;
    Transform tr;
    Animator ani;
 
    public bool isOpened;
    public PlayerController playerScript;
    public float rotAngle = 80;

    public float aniSpeed;

    public bool locked;

    private AudioSource audioS;
    public AudioClip[] clips; //0-jiggle/1-unlock/2-dooropen
    //public Transform from;
    //public Transform to;

    public AudioSource doorcreak;
    public AudioSource doorcreak_close;
    

    void Start()
    {
        tr = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        playerScript = player.gameObject.GetComponent<PlayerController>();
        audioS = GetComponent<AudioSource>();
      // from.rotation = tr.rotation;
      //  to.rotation = Quaternion.Euler(tr.rotation.eulerAngles.x, tr.rotation.eulerAngles.y + rotAngle, tr.rotation.eulerAngles.z);
        isOpened = false;
       
    }

    void Update()
    {
       /* if (locked && playerScript.keyItem){
            locked = false;
        }*/
    }


    public float DotProduct() {
        Vector3 doorToPlayer = player.position - tr.position;
        float dotProduct = Vector3.Dot(transform.right, doorToPlayer);
        return dotProduct;
        //Debug.Log("dotProduct: " + dotProduct);
    }
    public void DoorOpenClose()
    {
        if (locked && playerScript.keyItem)
        {
            audioS.PlayOneShot(clips[1]); //unlock sound
            
            locked = false;
            playerScript.keyItem = false;
            
        }
       
        if (locked) {
            if (!audioS.isPlaying)
            {
                audioS.PlayOneShot(clips[0]);
                ani.SetTrigger("DoorLocked");
            }
            return; } 
      
        if (!isOpened)
        {
            // if (!audioS.isPlaying) //door open sound
            // {
            //     audioS.PlayOneShot(clips[2],0.4f);
            // }
            doorcreak.Play();
            if (DotProduct() > 0)
            {
               
                aniSpeed = 1f;
                ani.SetTrigger("Door");

            }
            else if (DotProduct() < 0)
            {
                aniSpeed = -1f;
              

                ani.Play("Door-1");
            }

            isOpened = true;
        }
        else {
            // if (!audioS.isPlaying) //door close sound
            // {
            //     audioS.PlayOneShot(clips[2],0.4f);
            // }
             doorcreak_close.Play();

            if (aniSpeed == 1f)
            {
                aniSpeed = -1f;
                ani.SetTrigger("Door");

                /*   ani.SetFloat("DoorAniSpeed", aniSpeed);
                   ani.Play("Door");*/
            }
            else if (aniSpeed == -1f) {
                // aniSpeed = -1f;
                // ani.SetFloat("DoorAniSpeed", aniSpeed);
                //  ani.Play("Door-1");
                ani.SetTrigger("Door-1");
            }
  
            isOpened = false;

        }

        // Debug.Log(DotProduct());
    }

}
