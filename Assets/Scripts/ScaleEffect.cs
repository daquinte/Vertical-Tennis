using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{

    public float maxValue = 1;
    public float minValue = 0.5f;

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
        Debug.Log(maxValue + " " + minValue);
        if (upwards)
        {
            medidor += 0.2f * Time.fixedUnscaledDeltaTime;
            if (medidor > maxValue) upwards = false;
        }
        else
        {
            medidor -= 0.2f * Time.fixedUnscaledDeltaTime;
            if (medidor < minValue) upwards = true;

        }
        Debug.Log(medidor);        Debug.Log(upwards);
        gameObject.transform.localScale = new Vector3(medidor, medidor);
    }

}
