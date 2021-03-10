using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy3Script : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject temp;
    public Transform basecoord;

    public Slider enemyhealthBar;
    public int maxHealth = 50;
    public int currentHealth = 50;

    void Start()
    {
        basecoord = GameObject.Find("base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        currentHealth = maxHealth;
        enemyhealthBar.maxValue = maxHealth;
        enemyhealthBar.value = maxHealth;

    }

    void Update()
    {
        agent.destination = basecoord.position;

        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(5);
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            enemySpawner.Instance.enemy3Killed++;
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
            enemySpawner.Instance.enemy3Killed++;
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
