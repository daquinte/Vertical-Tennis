using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorFlecha : MonoBehaviour
{
    public Pelota pelota;

    // Use this for initialization
    void Start()
    {
        float heigh = GameManager.instance.GetHeight();
        transform.localPosition = new Vector3(0, heigh / 2 - 1.5f, -1); //-1 para que esté delante de los bloques
    }

    // Update is called once per frame
    /// <summary>
    /// Si la posicion Y de la pelota es mayor, está por encima de "height" y la flecha marca dónde se encuentra
    /// Cuando deje de serlo, se apagará hasta que el límite superior le avise
    /// </summary>
    void Update()
    {
        if (gameObject.activeSelf)
        {
            float yPelota = pelota.gameObject.transform.position.y;
            if (yPelota > transform.position.y)
            {
                float xPelota = pelota.gameObject.transform.position.x; //Pongo la nueva X
                transform.localPosition = new Vector3(xPelota, transform.position.y, -1);
            }

            else gameObject.SetActive(false); //Apago la flecha
        }
    }
}