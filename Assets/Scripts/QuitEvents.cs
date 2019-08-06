using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class QuitEvents : MonoBehaviour {

    private bool isQuitting;                        //¿Está el jugador queriendo irse de la partida?
    private Button quitButton;                      //Referencia al botón (Aun no se bien para qué)
    

	// Use this for initialization
	void Start () {
        quitButton = GetComponent<Button>();
        isQuitting = false;
	}

    private void Update()
    {
        //TODO:
        //Hacer que el botón se enrojezca en función del tiempo (En plan ojo cuidao)
        if (isQuitting)
        {
            Image bImage = quitButton.GetComponent<Image>();
            float G = bImage.color.g - 0.01f;
            float B = bImage.color.b - 0.01f;
            bImage.color = new Color(255, G, B, 255);

        }
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
            lc.OnMainMenu();
        }
        yield return null; //Quit corroutine
    }

    //Controla si se ha levantado el dedo antes del tiempo
    public void OnQuitRelease()
    {
        Debug.Log("OUT");
        isQuitting = false;
        quitButton.GetComponent<Image>().color = Color.white;
    }

}
