using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que gestiona el flujo de juego a lo largo de un nivel
/// </summary>
public class LevelManager : MonoBehaviour
{

    private LevelCanvas levelCanvas;                                //Referencia al panel para el estado de pausa. (TODO: ¿Está bien aqui?)
    private int puntosNivel;                                //Cantidad de puntos actuales.
    private int puntosOtorgar = 10;                         //Cantidad de puntos a entregar.
    private int puntosMax;                                  //Highscore de esta sesión
    private bool IsPaused;                                  //¿Está pausado?

    // Use this for initialization
    void Start()
    {
        puntosNivel = 0;
        puntosMax = GameManager.instance.GetSessionMaxPoints();
        IsPaused = false;
        FindMainCanvas();
        Time.timeScale = 0;
        levelCanvas.StartCountDown(3, ResumeGame);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ContinueGame();
    }

    /// <summary>
    /// Relativo a los puntos
    /// </summary>
    public void SumaPuntos()
    {
        puntosNivel += puntosOtorgar;
        if(puntosNivel > puntosMax)
        {
            puntosMax = puntosNivel;
        }
    }

    public int GetPuntosNivel()
    {
        return puntosNivel;
    }

    /// <summary>
    /// Construye un rectangulo que representa el viewport de la cámara actual
    /// y lo devuelve
    /// </summary>
    /// <returns>Viewport actual</returns>
    public Rect GetCameraRect()
    {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));

        //Rectangulo que representa el viewport de la camara
        Rect cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);

        return cameraRect;

    }

    //Metodos de gestión del canvas
    ///Lo siento Pedro Pablo, te he fallado
    public LevelCanvas GetMainCanvas()
    {
        if (levelCanvas == null) FindMainCanvas();
        return levelCanvas;
    }
    private void FindMainCanvas()
    {
        GameObject aux = GameObject.Find("Canvas");
        if (aux != null)
        {
            levelCanvas = aux.GetComponent<LevelCanvas>();
        }
        else Debug.Log("No encuentro el canvas");
    }

    public void OnPlayerDeath()
    {
        GameManager.instance.SetSessionMaxPoints(puntosMax);
        levelCanvas.SetPanelMuerte(true);
        IsPaused = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Métodos de la gestión de pausa
    /// </summary>

    public bool GetPaused() { return IsPaused; }

    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0;
        levelCanvas.SetPanelPausa(true);
        levelCanvas.SetPauseButton(false);

    }

    public void ContinueGame()
    {
        levelCanvas.StartCountDown(3, ResumeGame);
    }

    private void ResumeGame(LevelCanvas levelCanvas)
    {
        IsPaused = false;
        Time.timeScale = 1;
        levelCanvas.SetPauseButton(true);
    }

    public void GoToMenu()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        //Te lleva al menú -> avisa a GM de que tiene que pasarse al menú, guarda informacion y espera a ser destruido por GM
        GameManager.instance.SetSessionMaxPoints(puntosMax);
        GameManager.instance.QuitGame();
    }
}