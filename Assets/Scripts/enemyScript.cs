using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class enemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject temp;
    public Transform basecoord;

    public Slider enemyhealthBar;
    public int maxHealth = 15;
    public int currentHealth = 15;

    void Start()
    {
        basecoord = GameObject.Find("base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        currentHealth = 15;
        enemyhealthBar.maxValue = 15;
        enemyhealthBar.value = 15;
    }

    void Update()
    {
        agent.destination = basecoord.position;

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    TakeDamage(5);
        //}
        if (currentHealth <= 0)
        {
            enemySpawner.Instance.enemy1Killed++;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet1"))
        {
            TakeDamage(5);
        }
        if(other.gameObject.CompareTag("bullet2"))
        {
            TakeDamage(15);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("base"))
        {
            Destroy(gameObject);
            enemySpawner.Instance.enemy1Killed++;
        }
        if (col.gameObject.layer == 8)
        {
            Physics.IgnoreCollision(col.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemyhealthBar.value = currentHealth;
    }
}
