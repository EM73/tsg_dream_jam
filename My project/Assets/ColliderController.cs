using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField]
    private WebCameraController _webCameraController;

    [SerializeField] private Color _color;
    [SerializeField] private float _strength;
    [SerializeField] private float offset;
    [SerializeField] private float multiplayer;

    private Vector3 min;
    private Vector3 max;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<int> list = new List<int>();
        for (int i = 0; i < _webCameraController.tex.width; i++)
        {
            if (Vector3.Distance(ToVector3(_webCameraController
                        .tex.GetPixel(i, _webCameraController.tex.height / 2)),
                    ToVector3(_color)) > _strength)
            {
                list.Add(i);
            }
        }

        min = new Vector3(offset,transform.position.y,
            transform.position.z);
        
        max = new Vector3(offset+_webCameraController.tex.width*multiplayer,transform.position.y,
            transform.position.z);
        
        transform.position = new Vector3((float)list.Average() * multiplayer + offset, 
            transform.position.y,
            transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(min, Vector3.one);
        Gizmos.DrawCube(max, Vector3.one);
    }

    Vector3 ToVector3(Color color)
    {
        return new Vector3(color.r, color.g, color.b);
    }
        
}
