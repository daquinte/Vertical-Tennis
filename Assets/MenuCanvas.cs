using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour {

    public GameObject panelControles;

	// Use this for initialization
	void Start () {
        panelControles.SetActive(false);
	}
	
	public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }

    public void TooglePanelControles()
    {
        if (panelControles.activeSelf) { panelControles.SetActive(false); }
        else panelControles.SetActive(true);
    }
}
