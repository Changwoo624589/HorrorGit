using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    public Drawer[] Drawers;
    bool drawerUnlock;
    void Start()
    {
        drawerUnlock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!drawerUnlock)
        {
            if (
            Drawers[0].isOpened == true &&
            Drawers[1].isOpened == false &&
            Drawers[2].isOpened == false &&
            Drawers[3].isOpened == true &&
            Drawers[4].isOpened == false &&
            Drawers[5].isOpened == true &&
            Drawers[6].isOpened == true &&
            Drawers[7].isOpened == false
            )
            {
                Drawers[4].isOpened = true;
                Drawers[4].gameObject.GetComponent<MeshCollider>().enabled = true;
                drawerUnlock = true;
            }
        }
    }
}
