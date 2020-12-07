using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{

    public Material lightWalls;
    public Material darkWalls;

    public GameObject door;

    public MeshRenderer[] wallmesh;

    public SpriteRenderer sr;
    public Sprite goodbun;
    public Sprite badbun;

    public Light reglight;
    public float flickerSpeed = 0.1f;
    private float timer; 


    // Update is called once per frame
    void Update()
    {
        if (sr.sprite == null)
        { 
            sr.sprite = goodbun;
        }

        for (int i = 0; i < wallmesh.Length; i++)
        {
            wallmesh[i].GetComponent<MeshRenderer>();
        }

    }

    public void ChangeMaterials(Material darkWalls)
    {

        for (int i = 0; i < wallmesh.Length; i++)
        {

            wallmesh[i].GetComponent<MeshRenderer>().material = new Material(darkWalls);
 
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "turnaround")
        {
            ChangeMaterials(darkWalls);
            StartCoroutine(Blink(flickerSpeed));  

            sr.sprite = badbun;

            GameManager.Instance.darkMode = true;
        }
       
    }

    IEnumerator Blink(float flickerSpeed)
    {
        WaitForSeconds waitTime = new WaitForSeconds(flickerSpeed);
        while (true)
        {
            reglight.enabled = !reglight.enabled;
            yield return waitTime; 
        }
    }
}

