using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour
{
    
    public bool shakeable;
    private Animator ani;
    public bool dead;
    void Start()
    {
        ani = GetComponent<Animator>();
        dead = false;
    }

    void Update()
    {
        
    }

    public void FrameAni() {
        if (!dead && shakeable)
        {
            ani.SetTrigger("Shake");
        }
        else if (!shakeable && !dead) {
            ani.SetTrigger("Drop");
            BoxCollider bc = GetComponent<BoxCollider>();
            bc.enabled = false;
            dead = true;
        }
    }
}
