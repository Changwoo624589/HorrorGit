﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed = 12f;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    bool isGrounded;
    //ray
    public Camera mainCam;
    public float range;
    bool hitting;
    public LayerMask hitMask;
    
    public Image aim;

    /// <summary>
    /// 
    /// </summary>
    bool keyItem;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        keyItem = false;
    }

    void Update()
    {
        PlayerMovement();
        Aim();
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void Aim() {
        RaycastHit hit;
        hitting = Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range);
        if (hit.transform == null) 
        {
            aim.color = new Color32(255, 255, 255, 40);
            return;
        }
        if (hit.transform.gameObject.layer  == LayerMask.NameToLayer("Hitable")&& hitting)
        {
            Debug.Log(hit.transform.name);
            aim.color = new Color32(255, 200, 0, 255);
            Drawer drawer = hit.transform.GetComponent<Drawer>();
            if (drawer != null && Input.GetButtonDown("Fire1")) {
                //drawer.OpenDrawer();
                drawer.isOpened = !drawer.isOpened;
            }
            if (hit.transform.tag == "Key" && Input.GetButtonDown("Fire1")) {
                hit.transform.gameObject.SetActive(false);
                keyItem = true;
            }
        }
        
        else { aim.color = new Color32(255, 255, 255, 40); }

    }
}
