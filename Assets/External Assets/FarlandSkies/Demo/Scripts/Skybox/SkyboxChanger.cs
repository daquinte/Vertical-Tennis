using UnityEngine;
using UnityEngine.UI;

public class SkyboxChanger : MonoBehaviour
{
    public Material[] Skyboxes;
    public Shader shader;
    

    public void Awake()
    {
        RenderSettings.skybox = Skyboxes[0];
    }

    public void ChangeSkybox()
    {
        RenderSettings.skybox = Skyboxes[0];
        RenderSettings.skybox.SetFloat("_Rotation", 0);
    }
}