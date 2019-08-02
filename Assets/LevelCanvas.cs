using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Visual dice que no existe, pero si existe y se usa :)


public class LevelCanvas : MonoBehaviour {

    
    public TextMeshProUGUI textoPuntos;
    public GameObject panelPausa;
    public GameObject panelMuerte;

	// Use this for initialization
	void Start () {
        panelPausa.SetActive(false);         //En caso de que estuviera encendido.
	}
	
	// Update is called once per frame
	void Update () {
        textoPuntos.text = "Puntos: " + (GameManager.instance.GetLevelManager().GetPuntosNivel()).ToString();
	}

    public void SetPanelPausa(bool state)
    {
        panelPausa.SetActive(state);
    }

    public void SetPanelMuerte(bool state)
    {
        panelMuerte.SetActive(state);
    }

    public void OnContinue()
    {
        GameManager.instance.GetLevelManager().ContinueGame();
        SetPanelPausa(false);
        ///CODIGO DEL COUNTDOWN
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
}
