using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GlobalEnums.Affinity affinity;
    public int affinityLevel = 1;

    public int health = 100;

    private int maxHealth;

    [Space]

    public Image healthBarImage;
    public Text healthText;

    public StatusValuePopupText statusValuePopupText;

    private void Start()
    {
        maxHealth = health;
    }

    private void ChangeHealth(int change)
    {
        health += change;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        else if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBarImage.fillAmount = (float)health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }

    public void TakeDamage(int damage)
    {
        ChangeHealth(-damage);
        statusValuePopupText.ShowText($"-{damage}", Color.red);
    }

    public void TakeHealing(int healing)
    {
        ChangeHealth(healing);
        statusValuePopupText.ShowText($"+{healing}", Color.green);
    }

    public void Die()
    {
        print("Player Died");
    }
}
