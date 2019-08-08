using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour {

    public int maxHealth = 3;
    public float downwardsMovement = 0.08f;
    public Material blockMaterial;

    private int currentHealth;
    private Color firstHit = Color.yellow;
    private Color secondHit = Color.white;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (!GameManager.instance.GetLevelManager().GetPaused()) {
            transform.Translate(new Vector3(0, -downwardsMovement, 0), Space.Self);
        }
    }

    /// <summary>
    /// Revisa si el objeto colisionado es una pelota. En caso afirmativo, resta vida y calcula el nuevo color que debe tomar el shader.
    /// Si la vida fuera 0, avisa a Level Manager y se destruye.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pelota p = collision.gameObject.GetComponent<Pelota>();

        if (p != null)
        {
            currentHealth--;
            
            if (currentHealth <= 0)
            {
                GameManager.instance.GetLevelManager().SumaPuntos();
                Destroy(gameObject);
            }
            else
            {
                float healthPercentage = (currentHealth * 100) / maxHealth;
                //Si % de vida es mayor a 50, está en el rango "primer golpe".
                //En caso contrario estará en el segundo rango.
                if(healthPercentage > 50)
                {
                    GetComponent<Renderer>().material.SetColor("_Color", firstHit);
                }
                else
                {
                    GetComponent<Renderer>().material.SetColor("_Color", secondHit);
                }

            }
        }
    }

}
