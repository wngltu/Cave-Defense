using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy4Script : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject temp;
    public Transform basecoord;

    public Slider enemyhealthBar;
    public int maxHealth = 45;
    public int currentHealth = 45;

    void Start()
    {
        basecoord = GameObject.Find("base").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();

        currentHealth = 45;
        enemyhealthBar.maxValue = 45;
        enemyhealthBar.value = 45;

    }

    void Update()
    {
        agent.destination = basecoord.position;

        // (Input.GetKeyDown(KeyCode.F))
        //{
        //    TakeDamage(5);
        //}
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            enemySpawner.Instance.enemy4Killed++;
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
            enemySpawner.Instance.enemy4Killed++;
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
