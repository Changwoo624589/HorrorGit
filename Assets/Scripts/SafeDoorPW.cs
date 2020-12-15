using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SafeDoorPW : MonoBehaviour
{
    public int pw;
    public Text text;
    private AudioSource audioSource;
    public SafeDoor safeDoorScirpt;
    void Start()
    {
        pw = 0;
        audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (safeDoorScirpt.unlocked) {
            text.color = Color.green;
        }
    }
    public void InsertPW(){
        if (safeDoorScirpt.unlocked) return;

        audioSource.Play();
        pw++;
        if (pw >= 10) { pw = 0; }
        text.text = pw.ToString();

    }
}
