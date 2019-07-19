using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        Pala p = collision.gameObject.GetComponent<Pala>();

        if (p != null)
        {    
            // Calculate Angle Between the collision point 
            Vector3 dir = collision.contacts[0].point - transform.position;
            dir = -dir.normalized;           
            Debug.Log(p.GetVelocity());
            GetComponent<Rigidbody>().AddForce(dir * p.GetVelocity(), ForceMode.VelocityChange);
        }
    }


}
