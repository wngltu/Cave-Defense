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
    public float maxEnergy = 150;
    public float currentEnergy = 100;

    public TextMeshProUGUI wintext;
    public Text hptext;
    public Text energytext;
    public GameObject panel;

    public static playerController Instance;
    void Start()
    {
        Instance = this;

        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;

        currentEnergy = 100;
        energyBar.maxValue = 150;
        energyBar.value = 100;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            wintext.text = "Game Over";
        }
        if (currentEnergy <= 150)
        {
            currentEnergy = currentEnergy + (Time.deltaTime * 4);
            energyBar.value = currentEnergy;
            energytext.text = energyBar.value.ToString();
        }
        hptext.text = healthBar.value.ToString();
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
