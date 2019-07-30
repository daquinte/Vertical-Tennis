using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider col)
    {
        Bloque b = col.GetComponent<Bloque>();
        if (b != null)
        {
            Pala p = GetComponentInParent<Pala>();          
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
