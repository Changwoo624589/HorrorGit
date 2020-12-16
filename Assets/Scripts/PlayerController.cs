using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    //Audio
    private AudioSource aud;
    public AudioClip[] clips; //[0]:cloth belt(key)
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

    public GameObject panel; 

    /// <summary>
    /// 
    /// </summary>
    public bool keyItem;
   // public AudioSource keysound;
    
    //public bool drawerB;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        keyItem = false;
      //  drawerB = false;
    }

    void Update()
    {
        if (GameManager.Instance.start)
        {
            PlayerMovement();
            Aim();
        }
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
            //Debug.Log(hit.transform.name);//transform name        33333333333333333333333333333333333
            aim.color = new Color32(255, 200, 0, 255);
            Drawer drawer = hit.transform.GetComponent<Drawer>();
           

            /// Press Mouse1 or E
            if (Input.GetButtonDown("Fire1")) {
               
                if (drawer != null) 
                { drawer.isOpened = !drawer.isOpened; }

                if (hit.transform.tag == "Door")
                {
                    if (hit.transform.GetComponent<Door>() != null)
                    {
                        hit.transform.GetComponent<Door>().DoorOpenClose();
                    }
                }
                if (hit.transform.tag == "Key")
                {
                    hit.transform.gameObject.SetActive(false);



                    keyItem = true;
                    aud.PlayOneShot(clips[0]);
                }
                else if (hit.transform.tag == "Paper")
                {
                    panel.SetActive(true);
                }
                else if (hit.transform.GetComponent<Frame>() != null)
                {
                    hit.transform.GetComponent<Frame>().FrameAni();
                }
                else if (hit.transform.GetComponent<SafeDoorPW>() != null)
                {
                    hit.transform.GetComponent<SafeDoorPW>().InsertPW();
                }
                else if (hit.transform.GetComponent<LightSwitch>() != null) {
                    hit.transform.GetComponent<LightSwitch>().LightToggle();
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                panel.SetActive(false);
            }
            
        }
        
        else { aim.color = new Color32(255, 255, 255, 40); }

    }

    //public void OpenPanel()
    //{
    //    if (panel != null)
    //    {
    //        bool isActive = panel.activeSelf;

    //        panel.SetActive(!isActive);
    //    }
    //}
}
