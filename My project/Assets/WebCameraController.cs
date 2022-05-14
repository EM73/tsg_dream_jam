using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCameraController : MonoBehaviour
{

    public WebCamTexture tex { get; set; }
    [SerializeField] private int cam;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        for(int i = 0; i < devices.Length; i++)
        {
            Debug.Log("Webcam available: " + devices[i].name);
        }

        Renderer rend = this.GetComponent<Renderer>();
        
        tex = new WebCamTexture(devices[cam].name);
        rend.material.mainTexture = tex;
        tex.Play();    
    }

    void Update()
    {
        
    }
}
