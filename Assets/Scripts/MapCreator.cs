using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este componente crea elementos de juego (bloques, de momento) de forma aleatoria
/// Se encarga de gestionar la dificultad del juego, y de colocar patrones de bloques
/// respetando siempre la resolución de los objetos
/// </summary>
public class MapCreator : MonoBehaviour
{

    public GameObject prefabBloque;

    public int blocksPerRow = 10;

    private LevelManager levelManager;
    private int difficulty = 15;
    private float height;
    private float width;

    // Use this for initialization
    void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height; // basically height * screen aspect ratio
        //InvokeRepeating("CreateRow", 3, difficulty);
        StartCoroutine(GameFlow());
    }


    IEnumerator GameFlow()
    {
        yield return new WaitForSeconds(2.5f);

        while (!levelManager.GetPaused()) { 
            CreateRow();
            yield return new WaitForSeconds(difficulty);
        }
    }

    private void CreateRow()
    {
        float tamBloque = width / blocksPerRow; //Lo que debe ocupar cada bloque
        float firstXPos = -width / 2 + 0.8f;
        for (int i = 0; i < blocksPerRow; i++)
        {
            GameObject aux = Instantiate(prefabBloque);
            aux.transform.localScale = new Vector3(tamBloque, 1);
            aux.transform.localPosition = new Vector3(firstXPos + (tamBloque * i), height / 2);
        }
    }
}
