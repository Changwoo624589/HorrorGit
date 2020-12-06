using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public bool gameOver;
    public bool win;
    public bool pause;
    public bool darkMode;

    public float fogDensityinDarkMode;
    public float fogDensityinBrightMode;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;
        if (buildIndex == 0)
        {  Cursor.visible = true; Cursor.lockState = CursorLockMode.None; }
        else { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; }
        
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    void Start()
    {
        gameOver = false;
        win = false;
        pause = false;
        darkMode = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            darkMode = !darkMode;
        }
        DarkMode();
    }

    public void Win()
    {
        win = true;
        Cursor.visible = true;
    }
    public void GameOver()
    {
        gameOver = true;
        Cursor.visible = true;
    }
    public void Pause()
    {
        pause = !pause;

        Cursor.visible = pause;
        
        if (pause) { 
            Time.timeScale = 0.001f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        { 
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        Debug.Log("Cancel");
    }
    private void DarkMode() {

        if (darkMode)
        {
            RenderSettings.fogColor = Color.black;
            RenderSettings.fogDensity = fogDensityinDarkMode;
            RenderSettings.ambientIntensity = 0f;
            RenderSettings.ambientLight = new Color32(17,47,106,255); // hex = #FFFFFF

        }
        else 
        {
            RenderSettings.fogColor = Color.white;
            RenderSettings.fogDensity = fogDensityinBrightMode;
            RenderSettings.ambientIntensity = 0f;
            RenderSettings.ambientLight = new Color32(231,213,185,255); // hex = #FFFFFF  
            //231 , 213,185 yellow
        }
    }
}
