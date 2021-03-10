using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    float cooldownTimer;
    float cooldownTimer2;
    float cooldownTimer3;
    float cooldownTimer4;

    public float cooldown = 3f;
    public float cooldown2 = 5f;
    public float cooldown3 = 10f;
    public float cooldown4 = 8f;


    public int amtEnemy1 = 0;
    public int enemy1Spawned = 0;
    public int enemy1Killed = 0;

    public int amtEnemy2 = 0;
    public int enemy2Spawned = 0;
    public int enemy2Killed = 0;

    public int amtEnemy3 = 0;
    public int enemy3Spawned = 0;
    public int enemy3Killed = 0;

    public int amtEnemy4 = 0;
    public int enemy4Spawned = 0;
    public int enemy4Killed = 0;

    public GameObject enemy1, enemy2, enemy3, enemy4;

    public static enemySpawner Instance;

    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        cooldownTimer2 += Time.deltaTime;
        cooldownTimer3 += Time.deltaTime;
        cooldownTimer4 += Time.deltaTime;

        if (cooldownTimer >= cooldown && amtEnemy1 > enemy1Spawned)
        {
            Instantiate(enemy1, transform.position, Quaternion.identity);
            cooldownTimer = 0;
            enemy1Spawned++;
        }

        if (cooldownTimer2 >= cooldown2 && amtEnemy2 > enemy2Spawned)
        {
            Instantiate(enemy2, transform.position, Quaternion.identity);
            cooldownTimer2 = 0;
            enemy2Spawned++;
        }

        if (cooldownTimer3 >= cooldown3 && amtEnemy3 > enemy3Spawned)
        {
            Instantiate(enemy3, transform.position, Quaternion.identity);
            cooldownTimer3 = 0;
            enemy3Spawned++;
        }

        if (cooldownTimer4 >= cooldown4 && amtEnemy4 > enemy4Spawned)
        {
            Instantiate(enemy4, transform.position, Quaternion.identity);
            cooldownTimer4 = 0;
            enemy4Spawned++;
        }


    }

}
