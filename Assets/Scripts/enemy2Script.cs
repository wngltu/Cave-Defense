using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy2Script : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject temp;
    public Transform basecoord;

    float scrollSpeed = .5f;


    //public Slider healthBar;
    //public int maxHealth = 5;
    //public int currentHealth = 5;

    Renderer rend;

    void Start()
    {
        basecoord = GameObject.Find("base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        //currentHealth = maxHealth;
        // healthBar.maxValue = maxHealth;
        //healthBar.value = maxHealth;

        rend = GetComponent<Renderer>();


    }

    void Update()
    {
        agent.destination = basecoord.position;

        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("base"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.layer == 8)
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
