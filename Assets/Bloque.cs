using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour {

    public int vida = 3;

    private void OnCollisionEnter(Collision collision)
    {
        Pelota p = collision.gameObject.GetComponent<Pelota>();

        if (p != null)
        {
            vida--;
            if (vida <= 0)
            {
                //Temporal, debería avisar a LevelManager
                GameManager.instance.GetLevelManager().SumaPuntos();
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Pala"))
        {
            Debug.Log("IT WORKS");
        }
    }

}
