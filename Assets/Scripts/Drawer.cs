using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Animator ani;
    public bool isOpened;
    Transform tr;
    public Vector3 closePos;
    void Start()
    {
        ani = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        isOpened = false;
        closePos = tr.localPosition;
    }

    void Update()
    {
        if (isOpened)
        {
            Vector3 openPos = new Vector3(tr.localPosition.x, tr.localPosition.y, closePos.z + 0.5f);
            tr.localPosition = Vector3.MoveTowards(tr.localPosition, openPos, 5f * Time.deltaTime);
            //ani.SetBool("Open", true);
            /*       if (Mathf.Abs(tr.position.z - openPos.z) <= 0f)
                   {
                       isOpened = !isOpened;
                   }*/

            return;
        }
        else {
            tr.localPosition = Vector3.MoveTowards(tr.localPosition, closePos, 5f * Time.deltaTime);

        }
    }
    public void OpenDrawer() {
        
        if (!isOpened)
        {
            Vector3 openPos = new Vector3(tr.position.x, tr.position.y, tr.position.z + 0.5f);
            tr.position = Vector3.MoveTowards(tr.position, openPos, 5f * Time.deltaTime);
            //ani.SetBool("Open", true);
            if (Mathf.Abs(tr.position.z - openPos.z) < 0.1f)
            {
                isOpened = !isOpened;
            }
            return;
        }
        else {
            tr.position = Vector3.MoveTowards(tr.position,closePos, 5f * Time.deltaTime);
            //ani.SetBool("Open", false);
            isOpened = !isOpened;

            return;
        }

    }
}
