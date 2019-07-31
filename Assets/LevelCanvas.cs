using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Visual dice que no existe, pero si existe y se usa :)


public class LevelCanvas : MonoBehaviour {

    
    public TextMeshProUGUI textoPuntos;
    public GameObject panel;

	// Use this for initialization
	void Start () {
        panel.SetActive(false);         //En caso de que estuviera encendido.
	}
	
	// Update is called once per frame
	void Update () {
        textoPuntos.text = "Puntos: " + (GameManager.instance.GetLevelManager().GetPuntosNivel()).ToString();
	}

    public void SetPanelPausa(bool state)
    {
        panel.SetActive(state);
    }

    public void OnContinue()
    {
        GameManager.instance.GetLevelManager().ContinueGame();
        SetPanelPausa(false);
        ///CODIGO DEL COUNTDOWN
    }

    public void OnQuit()
    {
        GameManager.instance.GetLevelManager().QuitGame();
        Debug.Log("ON QUIT");
    }
}
