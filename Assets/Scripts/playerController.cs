using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerController : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 100;
    public int currentHealth = 100;

    public Slider energyBar;
    public float maxEnergy = 100;
    public float currentEnergy = 50;

    public TextMeshProUGUI wintext;
    public GameObject panel;

    public static playerController Instance;
    void Start()
    {
        Instance = this;

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        currentEnergy = 50;
        energyBar.maxValue = maxEnergy;
        energyBar.value = 50;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            wintext.text = "Game Over";
        }
        if (currentEnergy <= 100)
        {
            currentEnergy = currentEnergy + (Time.deltaTime * 3);
            energyBar.value = currentEnergy;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("enemy1"))
        {
            TakeDamage(10);
        }
        if (col.gameObject.CompareTag("enemy2"))
        {
            TakeDamage(5);
        }
        if (col.gameObject.CompareTag("enemy3"))
        {
            TakeDamage(25);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.value = currentHealth;
    }

}
