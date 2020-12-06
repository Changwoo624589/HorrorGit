using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator ani;
    public bool isOpened;
    Transform tr;
    public Vector3 closePos;
    public Desk deskScript;

    public bool aaa;
    public int originInt;
    public int currentInt;

    void Start()
    {
        ani = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        
        isOpened = false;
        closePos = tr.localPosition;
        originInt = 0;
        currentInt = 3;
    }

    void Update()
    {
        soundOn();
        if (isOpened && aaa)
        {
            currentInt = 1;
            Vector3 openPos = new Vector3(tr.localPosition.x, tr.localPosition.y, closePos.z + 0.5f);
            tr.localPosition = Vector3.MoveTowards(tr.localPosition, openPos, 3f * Time.deltaTime);


            if (Mathf.Abs(tr.position.z - openPos.z) <= 0f)
            {
                aaa = false;
            }
            
            return;
        }
        else {
            currentInt = 0;

            tr.localPosition = Vector3.MoveTowards(tr.localPosition, closePos, 3f * Time.deltaTime);
           
            aaa = true;
        }
    }
    public void OpenDrawer(ref bool d) {
        
        if (d) //!isOpened
        {
            aaa = true;

            Vector3 openPos = new Vector3(tr.position.x, tr.position.y, tr.position.z + 0.5f);
            tr.position = Vector3.MoveTowards(tr.position, openPos, 5f * Time.deltaTime);


            return;
        }
        else {
            aaa = false;


            tr.position = Vector3.MoveTowards(tr.position,closePos, 5f * Time.deltaTime);


            return;
        }

    }
    private void soundOn() {
        if (originInt != currentInt && currentInt == 1)
        {
            //Desk Play open music
            deskScript.PlaySound(0);
            originInt = currentInt;
        }
        else if (originInt != currentInt && currentInt == 0)
        {
            //Desk Play close music
            deskScript.PlaySound(1);
            originInt = currentInt;
        }
    }
}
