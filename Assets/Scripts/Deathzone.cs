using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float heigh = GameManager.instance.GetHeight();
        float width = GameManager.instance.GetWidth();

        transform.localPosition = new Vector3(0, -heigh / 2 - 2);
        GetComponent<BoxCollider2D>().size = new Vector3(width * 2, 1);
    }
    /// <summary>
    /// Cuando un objeto atraviesa la deathzone, busca si son pelota u bloque.
    /// Si detecta uno de esos dos, el juego terminará
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pelota p = collision.GetComponent<Pelota>();
        Bloque b = collision.GetComponent<Bloque>();

        if (p != null || b!=null)
        {
            GameManager.instance.GetLevelManager().OnPlayerDeath();
        }
    }
}
