using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pala p = collision.gameObject.GetComponent<Pala>();

        if (p != null)
        {    
            // Calculate Angle Between the collision point 
            Vector3 dir = (Vector3)collision.contacts[0].point - transform.position;
            dir = -dir.normalized;           
            GetComponent<Rigidbody2D>().AddForce(dir * p.GetVelocity() * Time.deltaTime * 0.2f, ForceMode2D.Force);
        }
    }


}
