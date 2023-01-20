using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image healthBar;

    public float currentHealth;
    public float maxHealth;

    public Sprite greenBar;
    public Sprite yellowBar;
    public Sprite redBar;

    PlayerManager player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        maxHealth = player.maxHealth;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        currentHealth = player.GetCurrentHealth();
        healthBar.fillAmount = currentHealth / maxHealth;

        if (healthBar.fillAmount < 0.5)
        {
            if (healthBar.fillAmount < 0.2)
            {
                healthBar.sprite = redBar;
            }
            else
            {
                healthBar.sprite = yellowBar;
            }
        }else
        {
            healthBar.sprite = greenBar;
        }
    }
}
