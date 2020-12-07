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
        SceneManager.LoadScene(1);
    }
    public void ResumeButton() {
        GameManager.Instance.Pause();
    }
    public void SaveButton()
    {
        SaveSystem.SaveSettings(camLook);
        GameManager.Instance.Option();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }
    public void OptionButton() 
    {
        GameManager.Instance.Option();
    }
    public void CancelButton() {
        GameManager.Instance.Option();
    }
}
