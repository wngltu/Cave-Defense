﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpbarLookCamscript : MonoBehaviour
{
    public Canvas canvas;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        camera = GameObject.Find("cameraobject").GetComponent<Transform>();
        canvas.transform.LookAt(camera);
    }
}
