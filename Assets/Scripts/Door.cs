using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //public Transform from;
    //public Transform to;

    void Start()
    {
        tr = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        playerScript = player.gameObject.GetComponent<PlayerController>();
      // from.rotation = tr.rotation;
      //  to.rotation = Quaternion.Euler(tr.rotation.eulerAngles.x, tr.rotation.eulerAngles.y + rotAngle, tr.rotation.eulerAngles.z);
        isOpened = false;
       
    }

    void Update()
    {
        if (locked && playerScript.keyItem){
            locked = false;
        }
    }


    public float DotProduct() {
        Vector3 doorToPlayer = player.position - tr.position;
        float dotProduct = Vector3.Dot(transform.right, doorToPlayer);
        return dotProduct;
        //Debug.Log("dotProduct: " + dotProduct);
    }
    public void DoorOpenClose()
    {

        if (locked) return;
        if (!isOpened)
        {
            if (DotProduct() > 0)
            {
                aniSpeed = 1f;
               // ani.SetFloat("DoorAniSpeed", aniSpeed);
                ani.SetTrigger("Door");
                Debug.Log("openddd");
                //ani.Play("Door");

            }
            else if (DotProduct() < 0)
            {
                aniSpeed = -1f;
              
                //ani.SetFloat("DoorAniSpeed", aniSpeed);
                //ani.SetTrigger("Door-1");
                Debug.Log("--d");
                ani.Play("Door-1");
            }
           
            //ani.SetTrigger("Door");
            isOpened = true;
        }
        else {
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
