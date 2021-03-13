using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class waveManager : MonoBehaviour
{
    public float waveTimer = 8f;
    public int waveNum = 1;

    public TextMeshProUGUI wavetext;

    private void Start()
    {
        Invoke("wave", 5f);
    }
    void Update()
    {
        waveTimer -= Time.deltaTime;
        if (waveTimer <= 0f)
        {
            if (enemySpawner.Instance.amtEnemy1 == enemySpawner.Instance.enemy1Killed &&
                enemySpawner.Instance.amtEnemy2 == enemySpawner.Instance.enemy2Killed &&
                enemySpawner.Instance.amtEnemy3 == enemySpawner.Instance.enemy3Killed &&
                enemySpawner.Instance.amtEnemy4 == enemySpawner.Instance.enemy4Killed)
            {
                waveTimer = 10f;
                enemySpawner.Instance.enemy1Spawned = 0;
                enemySpawner.Instance.enemy2Spawned = 0;
                enemySpawner.Instance.enemy3Spawned = 0;
                enemySpawner.Instance.enemy4Spawned = 0;
                enemySpawner.Instance.enemy1Killed = 0;
                enemySpawner.Instance.enemy2Killed = 0;
                enemySpawner.Instance.enemy3Killed = 0;
                enemySpawner.Instance.enemy4Killed = 0;
                waveNum++;
                wave();
            }
            
        }    
    }

    void wave()
    {
        if (waveNum == 1)
        {
            enemySpawner.Instance.amtEnemy1 = 5;
            wavetext.text = "Wave 1";
        }
        else if (waveNum == 2)
        {
            enemySpawner.Instance.amtEnemy1 = 8;
            enemySpawner.Instance.amtEnemy2 = 1;
            wavetext.text = "Wave 2";
        }
        else if (waveNum == 3)
        {
            enemySpawner.Instance.amtEnemy1 = 10;
            enemySpawner.Instance.amtEnemy2 = 3;
            wavetext.text = "Wave 3";
        }
        else if (waveNum == 4)
        {
            enemySpawner.Instance.amtEnemy1 = 15;
            enemySpawner.Instance.amtEnemy2 = 5;
            wavetext.text = "Wave 4";
        }
        else if (waveNum == 5)
        {
            enemySpawner.Instance.amtEnemy1 = 5;
            enemySpawner.Instance.amtEnemy2 = 5;
            enemySpawner.Instance.amtEnemy3 = 1;
            wavetext.text = "Wave 5";
        }
        else if (waveNum == 6)
        {
            enemySpawner.Instance.amtEnemy1 = 5;
            enemySpawner.Instance.amtEnemy2 = 5;
            enemySpawner.Instance.amtEnemy4 = 1;
            enemySpawner.Instance.amtEnemy3 = 0;
            wavetext.text = "Wave 6";
        }
        else if (waveNum == 7)
        {
            enemySpawner.Instance.amtEnemy1 = 8;
            enemySpawner.Instance.amtEnemy2 = 8;
            enemySpawner.Instance.amtEnemy4 = 2;
            wavetext.text = "Wave 7";
        }
        else if (waveNum == 8)
        {
            enemySpawner.Instance.amtEnemy1 = 10;
            enemySpawner.Instance.amtEnemy2 = 10;
            enemySpawner.Instance.amtEnemy4 = 3;
            wavetext.text = "Wave 8";
        }
        else if (waveNum == 9)
        {
            enemySpawner.Instance.amtEnemy1 = 15;
            enemySpawner.Instance.amtEnemy2 = 10;
            enemySpawner.Instance.amtEnemy4 = 5;
            wavetext.text = "Wave 9";
        }
        else if (waveNum == 10)
        {
            enemySpawner.Instance.amtEnemy1 = 5;
            enemySpawner.Instance.amtEnemy2 = 10;
            enemySpawner.Instance.amtEnemy3 = 2;
            enemySpawner.Instance.amtEnemy4 = 3;
            wavetext.text = "Wave 10 ";
        }
        else if (waveNum == 11)
        {
            if (playerController.Instance.currentHealth != 0)
            {
                Time.timeScale = 0;
                playerController.Instance.panel.SetActive(true);
                playerController.Instance.wintext.text = "You Win!";
            }
        }
    }
}
