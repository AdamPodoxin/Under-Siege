using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Global.Affinity affinity;
    public int affinityLevel = 1;

    public Sprite[] affinitySprites;
    public Image crestImage;

    [Space]

    public int health = 100;
    private int maxHealth;

    public int strength = 100;
    private int maxStrength;

    [Space]

    public Image healthBarImage;
    public Text healthText;

    private float targetHealthFillAmount;

    [Space]

    public Image strengthBarImage;
    public Text strengthText;

    private float targetStrengthFillAmount;

    [Space]

    public StatusValuePopupText statusValuePopupText;
    public float barChangeSpeed = 5f;

    private void Start()
    {
        maxHealth = health;
        targetHealthFillAmount = (float)health / maxHealth;

        maxStrength = strength;
        targetStrengthFillAmount = (float)strength / maxStrength;

        crestImage.sprite = affinitySprites[(int)affinity];
    }

    private void Update()
    {
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, targetHealthFillAmount, barChangeSpeed * Time.deltaTime);
        strengthBarImage.fillAmount = Mathf.Lerp(strengthBarImage.fillAmount, targetStrengthFillAmount, barChangeSpeed * Time.deltaTime);
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

        targetHealthFillAmount = (float)health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        ChangeHealth(-damageInfo.damage);
        statusValuePopupText.ShowText($"-{damageInfo.damage}", Global.DamageTypeToColor(damageInfo.damageType));
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

    private void ChangeStrength(int change)
    {
        strength += change;

        if (strength <= 0)
        {
            strength = 0;
        }
        else if (strength > maxStrength)
        {
            strength = maxStrength;
        }

        targetStrengthFillAmount = (float)strength / maxStrength;
        strengthText.text = $"{strength}/{maxStrength}";
    }
}
