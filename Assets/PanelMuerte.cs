using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //mi Visual dice que no existe, pero si existe y se usa :)


/// <summary>
/// Gestiona los textos de distintas muertes(?), y muestra tanto la puntuación actual
/// como el highscore. En caso de que puntuacion>highscore, muestra un mensaje de felicitación
/// </summary>
public class PanelMuerte : MonoBehaviour {

    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoHighscore;

    private int puntos;
    private int maxPuntos;

    // Cuando se inicia el panel de muerte
    void OnEnable () {
        puntos = GameManager.instance.GetLevelManager().GetPuntosNivel();
        maxPuntos = GameManager.instance.GetSessionMaxPoints();

        textoPuntos.text = "Puntos: " + puntos.ToString();
        if(puntos == maxPuntos)
        {
            textoHighscore.text = "¡Has superado tu propio récord!";
        }
        else
            textoHighscore.text = "Récord: " + maxPuntos.ToString();
	}

}
