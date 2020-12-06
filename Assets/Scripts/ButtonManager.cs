using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void StartButton() {
        SceneManager.LoadScene(1);
    }
    public void ResumeButton() {
        GameManager.Instance.Pause();
    }
    public void PauseButton()
    {
        
    }
    public void QuitButton() 
    {
        Application.Quit();
    }
    public void HomeButton() {
        SceneManager.LoadScene(0);
    }
    public void RestartButton() {
        GameManager.Instance.Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }
}
