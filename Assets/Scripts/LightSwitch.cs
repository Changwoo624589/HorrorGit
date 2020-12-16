using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public void LightToggle() {
        GameManager.Instance.darkMode = !GameManager.Instance.darkMode;
    }
}
