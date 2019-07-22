using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private LevelManager levelManager;
    public static GameManager instance;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        //Depende del juego al que se juegue???
        levelManager = new LevelManager();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    ///
    //GETTERS AND SETTERS
    ///
    public LevelManager GetLevelManager()
    {
        return levelManager;
    }
}
