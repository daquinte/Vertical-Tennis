using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

    public float hitForce = 3;              ///Lo fuerte que va a salir despedida la pelota


    private void Start()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();

        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pala p = collision.gameObject.GetComponent<Pala>();

        if (p != null)
        {
           
            // Calculate Angle Between the collision point 
            Vector2 dir = collision.contacts[0].point - new Vector2(transform.position.x, transform.position.y);
            // We then get the opposite (-Vector2) and normalize it
            dir = -dir.normalized;
            Debug.Log(dir);
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            Debug.Log(p.GetVelocity());
            GetComponent<Rigidbody2D>().AddForce(dir * p.GetVelocity(), ForceMode2D.Impulse);
        }
    }


}
