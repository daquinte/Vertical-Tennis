using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Visual dice que no existe, pero si existe y se usa :)


public class LevelCanvas : MonoBehaviour {

    
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoCountDown;
    public GameObject panelPausa;
    public GameObject panelMuerte;
    public GameObject botonPausa;

	// Use this for initialization
	void Start () {
        panelPausa.SetActive(false);         //En caso de que estuviera encendido.
        botonPausa.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        textoPuntos.text = "Puntos: " + (GameManager.instance.GetLevelManager().GetPuntosNivel()).ToString();
	}

    public void SetPanelPausa(bool state)
    {
        panelPausa.SetActive(state);
    }

    public void SetPanelMuerte(bool state, string tipoMuerte = null)
    {
        if(tipoMuerte != null)
        {
            if(tipoMuerte == "pelota")
            {

            }
            else if(tipoMuerte == "bloque")
            {

            }
        }
        panelMuerte.SetActive(state);
    }

    public void SetPauseButton(bool state)
    {
        botonPausa.SetActive(state);
    }

    /// <summary>
    /// BUTTON CALLBACKS
    /// </summary>
    public void OnPause()
    {
        GameManager.instance.GetLevelManager().PauseGame();
    }

    public void OnContinue()
    {
        GameManager.instance.GetLevelManager().ContinueGame();
        SetPanelPausa(false);
    }

    public void OnReintentar()
    {
        SetPanelMuerte(false);
        GameManager.instance.GetLevelManager().ReloadScene();
    }
    public void OnMainMenu()
    {
        SetPanelMuerte(false);
        GameManager.instance.GetLevelManager().GoToMenu();
    }

    public void OnQuit()
    {
        GameManager.instance.GetLevelManager().QuitGame();
        Debug.Log("ON QUIT");
    }

    public void StartCountDown(int count, System.Action<LevelCanvas> callback)
    {
        textoCountDown.gameObject.SetActive(true);
        textoCountDown.text = count.ToString();
        StartCoroutine(CountDown(count, callback));
    }

    IEnumerator CountDown(int count, System.Action<LevelCanvas> callback)
    {
        
        while (count > 0) {
            yield return new WaitForSecondsRealtime(0.8f);
            count--;
            textoCountDown.text = count.ToString();
            yield return null;
        }
        textoCountDown.gameObject.SetActive(false);
        if (callback != null) callback(this);
    }
}
