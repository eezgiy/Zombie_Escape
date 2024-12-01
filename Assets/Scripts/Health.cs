using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    public Image healthBar;
    void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    public void TakeDamage(float amount,GameObject target)
    {
        currentHealth -= amount;
        Debug.Log(target.tag + " took damaj");
        if(currentHealth <= 0)
        {
            if (target.tag == "Player")
            {
                GameMaster.Instance.PlayerDied();
            }
            else if(target.tag == "Enemy")
            {
                GameMaster.Instance.EnemyDied(target);
            }
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
