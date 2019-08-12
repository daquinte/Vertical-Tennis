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
    private int index = 2;
    private float height;
    private float width;

    // Use this for initialization
    void Start()
    {
        levelManager = GetComponentInParent<LevelManager>();
        height = GameManager.instance.GetHeight();
        width = GameManager.instance.GetWidth(); 
        StartCoroutine(GameFlow());
    }


    IEnumerator GameFlow()
    {
        yield return new WaitForSeconds(2.0f);

        while (!levelManager.GetPaused()) { 
            CreateRow(index);
            yield return new WaitForSeconds(difficulty);
            if (difficulty - 1 > 0)
            {
                Debug.Log(difficulty);
               
                if (difficulty <= 8){
                    index = 1;
                    difficulty--;
                 }
                else difficulty -= 2;
            }
        }
    }

    private void CreateRow(int index)
    {
        float tamBloque = width / blocksPerRow; //Lo que debe ocupar cada bloque
        float firstXPos = -width / 2 + 0.8f;
        for (int i = 0; i < blocksPerRow; i+=index)
        {
            GameObject aux = Instantiate(prefabBloque);
            aux.transform.localScale = new Vector3(tamBloque, 1);
            aux.transform.localPosition = new Vector3(firstXPos + (tamBloque * i), height / 2);
        }
    }
}
