using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameField : MonoBehaviour
{

    public bool isLeftWall; //¿Es la pared de la izquierda?
    private ParticleSystem cloudSystem;

    // Use this for initialization
    void Start()
    {
        cloudSystem = GetComponentInChildren<ParticleSystem>();
        if (cloudSystem != null)
        {
            PlaceWalls();
        }
        else Debug.Log("You don´t seem to have a cloudSystem, friend");

    }

    /// <summary>
    /// Decide la posición y la escala relativa al tamaño de la pantalla y la resolución
    /// y la adapta en función de si es para el muro izquierdo o el derecho.
    /// </summary>
    private void PlaceWalls()
    {
        //Forma de sacar las dimensiones visibles -> ¿Las podría sacar de GM? Si, pero no jaj
        float height = Camera.main.orthographicSize * 2.0f;
        float width =  height * Screen.width / Screen.height; // basically height * screen aspect ratio

        //Posicion en función de la pared
        if (isLeftWall)
        {
            transform.localPosition = new Vector3(-width / 2, height / 2);           
        }
        else
        {
            transform.localPosition = new Vector3(width / 2, height / 2);

        }

        //Escalamos el muro y el ParticleSystem convenientemente
        transform.localScale = new Vector3(1.5f, height + 15, 0);
        Vector3 newCloudSystemScale = new Vector3(height, 1, 0);
        ParticleSystem.ShapeModule particleShape = cloudSystem.shape;
        particleShape.shapeType = ParticleSystemShapeType.Box;
        particleShape.scale = newCloudSystemScale;


    }


}
