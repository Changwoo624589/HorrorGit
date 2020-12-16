using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject secretpaper;
    public GameObject door;
    private Door doorScript;

    void Start()
    {
        secretpaper.SetActive(false);
        doorScript = GetComponent<Door>();
    }

    public void LightToggle() {
        GameManager.Instance.darkMode = !GameManager.Instance.darkMode;

        if(GameManager.Instance.darkMode){
            secretpaper.SetActive(true);
            door.GetComponent<Door>().locked = false;
        } else{
            secretpaper.SetActive(false);
            door.GetComponent<Door>().locked = true;
            }
    }
}
