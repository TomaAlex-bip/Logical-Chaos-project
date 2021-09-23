using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNGSkybox : MonoBehaviour
{
    
    [SerializeField] private Material[] skyboxes;


    private void Awake()
    {
        RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];


    }


}
