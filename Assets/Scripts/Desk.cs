using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    public Drawer[] Drawers;
    public bool drawerUnlock;
    public AudioClip[] sounds;
    private AudioSource audioSource;

    public GameObject player;
    public PlayerController playerScript;
    void Start()
    {
        drawerUnlock = false;
        audioSource = GetComponent<AudioSource>();
        playerScript = player.GetComponent<PlayerController>();
    }

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

    public void PlaySound(int num)
    {
            if (/*!audioSource.isPlaying &&*/ num == 0) { audioSource.PlayOneShot(sounds[0]); num = 3; }//open sound
            if (/*!audioSource.isPlaying && */num == 1) { audioSource.PlayOneShot(sounds[1]); num = 3; }//closed sound

    }
}
