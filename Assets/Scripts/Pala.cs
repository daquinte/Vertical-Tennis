using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
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

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateVelocity();

        //[TEMPORAL]
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
        GetComponent<Rigidbody>().AddForce(-objectVelocityVector * GetVelocity(), ForceMode.Force);
    }

    public float GetVelocity()
    {
        float velMagnitude = objectVelocityVector.magnitude;
        return velMagnitude > 0 ? velMagnitude : 1;
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
