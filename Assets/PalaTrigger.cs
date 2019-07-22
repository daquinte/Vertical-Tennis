using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        Bloque b = col.GetComponent<Bloque>();
        if (b != null)
        {
            
            Pala p = GetComponentInParent<Pala>();
            GetComponentInParent<Rigidbody>().isKinematic = false;
            p.AddOpositeForce();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        Bloque b = col.GetComponent<Bloque>();
        if(b != null)
        {
            GetComponentInParent<Rigidbody>().isKinematic = true;

        }
    }
}
