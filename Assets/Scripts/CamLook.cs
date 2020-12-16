using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float limitRot = 85f;
    float xRotation = 0f;
    //public Slider slider;

    void Start()
    {
/*        slider = GetComponent<Slider>();
        PlayerData data = SaveSystem.LoadSettings();
        this.mouseSensitivity = data._mouseSensitivity;
        */

    }

    void Update()
    {
        if (GameManager.Instance.start)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -limitRot, limitRot);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            playerBody.Rotate(Vector3.up * mouseX);
        }

    }

    public void MouseSensitivity(float sensitivity) {
        mouseSensitivity = sensitivity;
    }
}
