using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSelect : MonoBehaviour
{
    public int[] startGrid;
    private bool buttonD;
    void Start()
    {
        
    }

    
    void Update()
    {
        Movement();
    }
    private void Movement() {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (!buttonD)
            {
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    startGrid[0] = startGrid[0] - 1;
                    buttonD = true;
                }
                else if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    startGrid[0] += 1;
                    buttonD = true;
                }
                //Debug.Log(startGrid[0]);
            }
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            if (!buttonD)
            {
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    startGrid[1] -= 1;
                    buttonD = true;
                }
                else if (Input.GetAxisRaw("Vertical") > 0)
                {
                    startGrid[1] += 1;
                    buttonD = true;
                }
                //Debug.Log(startGrid[1]);
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            buttonD = false;
        }
    }
}
