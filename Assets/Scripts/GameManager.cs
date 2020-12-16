using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public bool start;
    public bool gameOver;
    public bool win;
    public bool pause;
    public bool darkMode;
    public bool option;
    public bool option2;
    public bool credit;
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
        { 
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
            start = false;
        }
        else { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; start = true; }
        darkMode = false; 
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
        //start = false;
        gameOver = false;
        win = false;
        pause = false;
        darkMode = false;
        option = false;
        credit = false;
        option2 = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            darkMode = !darkMode;
        }
        Scene currentScene = SceneManager.GetActiveScene();
        int buildIndex = currentScene.buildIndex;
        if (buildIndex > 0)
        {
            DarkMode();
        }
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
            Cursor.visible = false;
        }
        
        
    }
    public void Option() {
        option = !option;
        if (option && pause)
        {
            Time.timeScale = 0.001f;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    public void Option2() {
        
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

    public void Credit() {
        credit = !credit;
        if (credit) { Cursor.lockState = CursorLockMode.None; }
        
    }
    public void StartGame() {
        if (start)
        {
            Time.timeScale = 1f;
        }
        else { Time.timeScale = 0f; }
    }
    public void End() {
        GameManager.Instance.darkMode = false;
        GameManager.Instance.start = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().path);
        SceneManager.LoadScene(0);
    }
}
