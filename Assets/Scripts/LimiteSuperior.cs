using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteSuperior : MonoBehaviour {

    public IndicadorFlecha flecha;

	// Use this for initialization
	void Start () {
        float heigh = GameManager.instance.GetHeight();
        float width = GameManager.instance.GetWidth();

        transform.localPosition = new Vector3(0, heigh/2+1);
        GetComponent<BoxCollider2D>().size = new Vector3(width*2, 1);
    }
	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pelota p = collision.GetComponent<Pelota>();
        //Si es una pelota, activo la flecha
        if( p!= null)
        {
            flecha.gameObject.SetActive(true);
        }
    }
}
