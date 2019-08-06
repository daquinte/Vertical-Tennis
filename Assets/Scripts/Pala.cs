using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    /// <summary>
    /// Private variables
    /// </summary>
    private Vector3 mousePosition;
    private Vector3 objectPosition;
    private Vector3 objectVelocityVector;

    /// <summary>
    /// Public variables
    /// </summary>
    public float moveSpeed = 0.1f;          //Velocidad de la pala
    public float rotation = 3.0f;           //Rotacion de la pala [Hack temporal/mouse and keyboard play]

    // Use this for initialization
    void Start()
    {
        objectPosition = transform.position;
        float width = (Camera.main.orthographicSize * 2.0f) * (Screen.width / Screen.height); // basically height * screen aspect ratio
        transform.localScale = new Vector3 (width / 3, 1);
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
        Vector3 newObjectPosition = transform.position;
        Vector3 media = (newObjectPosition - objectPosition);
        objectVelocityVector = media / Time.deltaTime;

        objectPosition = newObjectPosition;
    }

    public void AddOpositeForce()
    {
        Debug.Log(-objectVelocityVector * GetVelocity());
        GetComponent<Rigidbody>().AddForce(-objectVelocityVector * GetVelocity()*2, ForceMode.Force);
    }

    public float GetVelocity()
    {
        float velMagnitude = objectVelocityVector.magnitude;
        //Controlamos la fuerza para que esté en valores [30-1]
        if (velMagnitude > 15f) velMagnitude = 15f;
        else if (velMagnitude < 0) velMagnitude = 1f;
        return velMagnitude;
    }

    private void MoveWithMousePos()
    {
       
     mousePosition = Input.mousePosition;
     mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
     GetComponent<Rigidbody>().MovePosition(Vector2.Lerp(transform.position, mousePosition, moveSpeed / Time.deltaTime));
        
    }

    /// <summary>
    /// Provoca que la pala se mantenga siempre detro de la cámara.
    /// </summary>
    private void StayInCameraBounds()
    {
        Rect camera = GameManager.instance.GetLevelManager().GetCameraRect();
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, camera.xMin, camera.xMax),
        Mathf.Clamp(transform.position.y, camera.yMin, camera.yMax),
        transform.position.z);
    }
}
