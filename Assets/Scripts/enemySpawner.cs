using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    float cooldownTimer;    
    public float cooldown = 3f;
    int enemysKilled;

    public GameObject enemy;
    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer >= cooldown)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            cooldownTimer = 0;
        }

    }
}
