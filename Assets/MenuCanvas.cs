using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour {

    public GameObject botones;
    private float upscaleFactor;

    private void Start()
    {
        botones.transform.localScale = Vector3.zero;

    }

    private void Update()
    {
        if (botones.transform.localScale.x < 1)
        {
            float scale = botones.transform.localScale.x + 0.4f * Time.unscaledDeltaTime;
            botones.transform.localScale = new Vector3(scale, scale);
        }
    }

	
	public void StartGame()
    {
        GameManager.instance.StartGame();
    }

    public void QuitGame()
    {
        GameManager.instance.QuitGame();
    }


}
