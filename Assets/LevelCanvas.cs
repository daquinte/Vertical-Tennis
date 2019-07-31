using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; //Visual dice que no existe, pero si existe y se usa


public class LevelCanvas : MonoBehaviour {

    
    public TextMeshProUGUI textoPuntos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        textoPuntos.text = "Puntos: " + (GameManager.instance.GetLevelManager().GetPuntosNivel()).ToString();
	}
}
