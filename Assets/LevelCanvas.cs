using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCanvas : MonoBehaviour {

    public Text textoPuntos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textoPuntos.text = "Puntos: " + (GameManager.instance.GetLevelManager().GetPuntosNivel()).ToString();
	}
}
