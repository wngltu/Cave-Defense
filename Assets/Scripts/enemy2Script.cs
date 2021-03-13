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


    public Slider enemy2healthBar;
    public int maxHealth = 10;
    public int currentHealth = 10;

    Renderer rend;

    void Start()
    {
        basecoord = GameObject.Find("base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        currentHealth = 10;
        enemy2healthBar.maxValue = 10;
        enemy2healthBar.value = 10;

        rend = GetComponent<Renderer>();


    }

    void Update()
    {
        agent.destination = basecoord.position;

        //if (Input.GetKeyDown(KeyCode.F))
        //{
       //     TakeDamage(5);
        //}
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            enemySpawner.Instance.enemy2Killed++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet1"))
        {
            TakeDamage(5);
        }
        if (other.gameObject.CompareTag("bullet2"))
        {
            TakeDamage(15);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("base"))
        {
            Destroy(gameObject);
            enemySpawner.Instance.enemy2Killed++;
        }
        if (col.gameObject.layer == 8)
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemy2healthBar.value = currentHealth;
    }
}
