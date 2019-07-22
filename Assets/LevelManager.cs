using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour {

    private int puntosNivel;
    private int puntosOtorgar = 10;

    // Use this for initialization
    void Start () {
        puntosNivel = 0;
	}

    /// <summary>
    /// Relativo a los puntos
    /// </summary>

    public void SumaPuntos()
    {
        puntosNivel += puntosOtorgar;
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
}
