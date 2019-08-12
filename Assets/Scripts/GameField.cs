using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameField : MonoBehaviour
{

    public bool isLeftWall; //¿Es la pared de la izquierda?
    public bool isTopWall;  //¿Es la pared de la superior?
    private ParticleSystem cloudSystem;

    private float height;
    private float width;

    // Use this for initialization
    void Start()
    {
        height = GameManager.instance.GetHeight();
        width = GameManager.instance.GetWidth();
        cloudSystem = GetComponentInChildren<ParticleSystem>();
        if (cloudSystem != null)
        {
            PlaceWalls();
        }
        else if (isTopWall)
        {
            PlaceTopWall();
        }
    }

    /// <summary>
    /// Coloca el muro superior, con una escala relativa al tamaño de la pantalla
    /// </summary>
    private void PlaceTopWall()
    {
        transform.localPosition = new Vector3(width/7, height);
        transform.localScale = new Vector3(0.5f, width+5, 0);
    }

    /// <summary>
    /// Decide la posición y la escala relativa al tamaño de la pantalla y la resolución
    /// y la adapta en función de si es para el muro izquierdo o el derecho.
    /// </summary>
    private void PlaceWalls()
    {
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
        transform.localScale = new Vector3(0.5f, height + 100, 0);
        Vector3 newCloudSystemScale = new Vector3(height+10, 1, 0);
        ParticleSystem.ShapeModule particleShape = cloudSystem.shape;
        particleShape.shapeType = ParticleSystemShapeType.Box;
        particleShape.scale = newCloudSystemScale;
    }


}
