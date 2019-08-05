using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LevelManager levelManager;               //Prefab de levelManager
    private LevelManager levelManagerInstance;      //Instancia actual de levelManager

    //Static instance
    public static GameManager instance;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    public void StartGame()
    {
        OnGameStart();
        levelManagerInstance = null;
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void OnGameStart()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EscenaPartida" && levelManagerInstance == null)
        {
            levelManagerInstance = Instantiate(levelManager);
        }
    }

    ///
    //GETTERS AND SETTERS
    ///
    public LevelManager GetLevelManager()
    {
        return levelManagerInstance;
    }


}
