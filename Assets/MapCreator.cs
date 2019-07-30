using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este componente crea elementos de juego (bloques, de momento) de forma aleatoria
/// Se encarga de gestionar la dificultad del juego, y de colocar patrones de bloques
/// respetando siempre la resolución de los objetos
/// </summary>
public class MapCreator : MonoBehaviour {

    public GameObject prefabBloque;
    public int blocksPerRow = 5;

    private int difficulty = 7;
    private float height;
    private float width;

    // Use this for initialization
    void Start () {
        height = Camera.main.orthographicSize * 2.0f;
        width  = height * Screen.width / Screen.height; // basically height * screen aspect ratio
        Debug.Log("HEIGH: " + height + "WIDTH: " + width);
        InvokeRepeating("CreateRow", 0, difficulty);
	}
	
    private void CreateRow()
    {
        float tamBloque = width / blocksPerRow; //Lo que debe ocupar cada bloque
        float firstXPos = -width/2 + 2;
        for(int i = 0; i < blocksPerRow; i++)
        {
            GameObject aux = Instantiate(prefabBloque);
            aux.transform.localScale = new Vector3(tamBloque , 1);           
            aux.transform.localPosition = new Vector3(firstXPos + (tamBloque*i), height/2);
        }
    }
}
