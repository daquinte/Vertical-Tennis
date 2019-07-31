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

    // Use this for initialization
    void Start()
    {
        OnGameStart();
    }

    //TEMPORALLL
    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
            OnGameStart();
    }

    private void OnGameStart()
    {
        levelManagerInstance = Instantiate(levelManager);
    }


    ///
    //GETTERS AND SETTERS
    ///
    public LevelManager GetLevelManager()
    {
        return levelManagerInstance;
    }


}
