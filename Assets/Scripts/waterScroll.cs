using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterScroll: MonoBehaviour
{

    float scrollSpeed = .5f;


    //public Slider healthBar;
    //public int maxHealth = 5;
    //public int currentHealth = 5;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();


    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset,offset));
    }
}
