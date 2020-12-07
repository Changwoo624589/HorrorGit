using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public float _mouseSensitivity;


    public PlayerData (CamLook camLook)
    {
        _mouseSensitivity = camLook.mouseSensitivity;
    }


}
