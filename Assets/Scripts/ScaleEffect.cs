using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{

    public float maxValue = 1;
    public float minValue = 0.5f;
    public float scaleFactor = 0.1f;

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
            medidor += scaleFactor * Time.fixedUnscaledDeltaTime;
            if (medidor > maxValue) upwards = false;
        }
        else
        {
            medidor -= scaleFactor * Time.fixedUnscaledDeltaTime;
            if (medidor < minValue) upwards = true;

        }

        gameObject.transform.localScale = new Vector3(medidor, medidor);
    }

}
