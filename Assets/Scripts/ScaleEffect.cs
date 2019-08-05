using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{

    public float maxValue;
    public float minValue;

    private bool upwards = true;
    private float medidor;
    // Use this for initialization
    void Start()
    {
        upwards = true;
    }

    void Update()
    {
        medidor = transform.localScale.x;
        if (upwards)
        {
            medidor += 0.1f * Time.deltaTime;
            if (medidor > maxValue) upwards = false;
        }
        else
        {
            medidor -= 0.1f * Time.deltaTime;
            if (medidor < minValue) upwards = true;

        }
        transform.localScale = new Vector3(medidor, medidor);
    }

}
