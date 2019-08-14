using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
     TODO: HACER QUE LA PALA SE DESPLACE, NO SE TELETRANSPORTE
     
     BUG: AL PULSAR EL BOTON DE PAUSA A VECES SE MUEVE LA BOLA, APARTE DE LA PALA QUE NO DEBErÍA MOVERSE :3*/

public class Pala : MonoBehaviour
{
    /// <summary>
    /// Private variables
    /// </summary>
    private Vector2 mousePosition;
    private Vector2 objectPosition;
    private Vector2 objectVelocityVector;

    /// <summary>
    /// Public variables
    /// </summary>
    public float moveSpeed = 0.1f;          //Velocidad de la pala
    public float rotation = 3.0f;           //Rotacion de la pala [Hack temporal/mouse and keyboard play]

    // Use this for initialization
    void Start()
    {
        objectPosition = transform.position;
        float width = GameManager.instance.GetWidth();
        transform.localScale = new Vector2 (width / 12, 0.2f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateVelocity();

        //[TEMPORAL?]
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1), rotation);
        }

        else if (Input.GetKey(KeyCode.E))
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1), -rotation);
        }

        MoveWithMousePos();
        StayInCameraBounds();
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Bloque b = collision.gameObject.GetComponent<Bloque>();
        if(b != null) {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            Vector3 dir = collision.contacts[0].point - transform.position; //Dirección de golpe
            dir = -dir.normalized;
            rb.AddForce(dir * 2, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Bloque b = collision.gameObject.GetComponent<Bloque>();
        if (b != null)
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }*/

    private void CalculateVelocity()
    {
        Vector2 newObjectPosition = transform.position;
        Vector2 media = (newObjectPosition - objectPosition);
        objectVelocityVector = media / Time.deltaTime;

        objectPosition = newObjectPosition;
    }


    public float GetVelocity()
    {
        float velMagnitude = objectVelocityVector.magnitude;
        //Controlamos la fuerza para que esté en un rango de valores
        if (velMagnitude > 10f) velMagnitude = 10f;
        else if (velMagnitude < 0) velMagnitude = 1f;
        return velMagnitude;
    }

    private void MoveWithMousePos()
    {
       
     mousePosition = Input.mousePosition;
     mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
     //TODO: mirar si lo podría hacer con un rayo para evitar pulsar sobre la pelota
     GetComponent<Rigidbody2D>().MovePosition(Vector2.Lerp(transform.position, mousePosition, moveSpeed / Time.deltaTime));
        
    }

    /// <summary>
    /// Provoca que la pala se mantenga siempre detro de la cámara.
    /// </summary>
    private void StayInCameraBounds()
    {
        Rect camera = GameManager.instance.GetLevelManager().GetCameraRect();
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, camera.xMin, camera.xMax),
        Mathf.Clamp(transform.position.y, camera.yMin, camera.yMax));
    }
}
