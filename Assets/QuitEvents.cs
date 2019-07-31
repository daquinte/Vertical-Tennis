using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class QuitEvents : MonoBehaviour {

    public int maxQuitTime = 50;                      //Tiempo que el usuario debe pulsar el botón para cerrar el juego

    private int currentQuitTime;                           //Tiempo que lleva el usuario pulsando el botón
    private bool isQuitting;                        //¿Está el jugador queriendo irse de la partida?
    private Button quitButton;                      //Referencia al botón (Aun no se bien para qué)

	// Use this for initialization
	void Start () {
        quitButton = GetComponent<Button>();
        isQuitting = false;
        currentQuitTime = 0;
	}

    private void Update()
    {
       
    }

    //Cuenta si has pulsado el botón durante el tiempo establecido
    public void OnQuitPress()
    {
        Debug.Log("IN");
        isQuitting = true;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        Debug.Log("waiting...");
        yield return new WaitForSecondsRealtime(1.5f);
        if (isQuitting)
        {
            LevelCanvas lc = GameManager.instance.GetLevelManager().GetMainCanvas();
            lc.OnQuit();
        }
        yield return null; //Quit corroutine
    }

    //Controla si se ha levantado el dedo antes del tiempo
    public void OnQuitRelease()
    {
        Debug.Log("OUT");
        isQuitting = false;
        currentQuitTime = 0;
    }

}
