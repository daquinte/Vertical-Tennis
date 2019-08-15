using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public LevelManager levelManager;               //Prefab de levelManager

    //Clases
    private LevelManager levelManagerInstance;      //Instancia actual de levelManager
    private Persistencia persistencia;              //Gestor de persistencia
    private RecordTracker recordTracker;            //Gestor de records

    private int sessionMaxPoints;

    private float height;
    private float width;

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
            RegisterScreenDimensions();
            sessionMaxPoints = 0;
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        //HACK TEMPORAL :)
        if (SceneManager.GetActiveScene().name == "EscenaPartida")
        {
            levelManagerInstance = Instantiate(levelManager);
        }
        //

        persistencia = GetComponent<Persistencia>();
        recordTracker = GetComponent<RecordTracker>();
    }

    /// Empieza una partida.
    public void StartGame()
    {
        OnGameStart();
        levelManagerInstance = null;
    }
    //Termina el juego
    public void QuitGame()
    {
        Application.Quit();
    }

    public int GetSessionMaxPoints()
    {
        return sessionMaxPoints;
    }


    public void SetSessionMaxPoints(int newValue)
    {
        sessionMaxPoints = newValue;
        VerificaRecord(sessionMaxPoints);
    }

    /// <summary>
    /// Comprueba si el parámetro es de valor suficiente para ser considerado un record.
    /// Si lo es, pedirá un nombre al usuario. Si no, se ignora
    /// </summary>
    /// <param name="posibleRecord"></param>
    private void VerificaRecord(int posibleRecord)
    {
        bool a = recordTracker.CompruebaRecord(posibleRecord);
    }

    //Load de la escena de juego y registra callback al método OnSceneLoaded
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

    private void RegisterScreenDimensions() {
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height; // basically height * screen aspect ratio
    }

    //Ancho y alto de la pantalla
    public float GetHeight() { return height; }
    public float GetWidth() { return width; }



}
