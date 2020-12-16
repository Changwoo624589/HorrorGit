using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public CamLook camLook;
    void Start()
    {
        LoadButton();
    }


    public void StartButton() {
        // SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.start = true;
    }

    public void ResumeButton() {
        GameManager.Instance.Pause();
    }
    public void SaveButton()
    {
        SaveSystem.SaveSettings(camLook);
        GameManager.Instance.Option();
    }
    public void SaveButtonStart() {
        SaveSystem.SaveSettings(camLook);
        GameManager.Instance.option2 = false;
    }
    public void LoadButton() 
    {
        PlayerData data = SaveSystem.LoadSettings();
        camLook.mouseSensitivity = data._mouseSensitivity;
    }
    public void QuitButton() 
    {
        Application.Quit();
    }
    public void HomeButton() {
        SceneManager.LoadScene(0);
    }
    public void RestartButton() {
        GameManager.Instance.darkMode = false;
        GameManager.Instance.Pause();
        GameManager.Instance.start = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        SceneManager.LoadScene(0);
    }
    public void OptionButton() 
    {
        GameManager.Instance.Option();
    }
    public void OptionButtonStart() 
    {
        GameManager.Instance.option2 = true;
    }
    public void CancelButton() {
        GameManager.Instance.Option();
    }
    public void CancelButton2() {
        GameManager.Instance.option2 = false;
    }
    public void CreditButton() {
        GameManager.Instance.Credit();
    }
}
