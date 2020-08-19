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

    public ArmorInfo equippedArmor;
    private bool isUsingArmor = false;

    [Space]

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
    private int maxArmorHealth;

    [Space]

    public GameObject armorUIParent;
    public Image armorBarImage;
    public Text armorText;

    private float targetArmorFillAmount;

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

        //TEMP
        StartCoroutine(ARMOR_TEST());
    }

    //TEMP
    private IEnumerator ARMOR_TEST()
    {
        EquipArmor(new ArmorInfo(1000, 1f, Global.DamageType.Physical));
        yield return new WaitForSeconds(1f);
        StartCoroutine(ARMOR_TEST());
    }

    private void Update()
    {
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, targetHealthFillAmount, barChangeSpeed * Time.deltaTime);
        strengthBarImage.fillAmount = Mathf.Lerp(strengthBarImage.fillAmount, targetStrengthFillAmount, barChangeSpeed * Time.deltaTime);

        if (isUsingArmor)
            armorBarImage.fillAmount = Mathf.Lerp(armorBarImage.fillAmount, targetArmorFillAmount, barChangeSpeed * Time.deltaTime);
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
        Global.DamageType damageType = damageInfo.damageType;
        int damageToPlayer = damageInfo.damage;

        bool doesArmorBlockDamageType = damageType.Equals(equippedArmor.armorType);
        int damageToArmor = (isUsingArmor && doesArmorBlockDamageType) ? Mathf.CeilToInt(damageToPlayer * equippedArmor.resistPercent) : 0;

        damageToPlayer -= damageToArmor;

        ChangeHealth(-damageToPlayer);
        statusValuePopupText.ShowText($"-{damageToPlayer}", Global.DamageTypeToColor(damageType));

        equippedArmor.armorHealth -= damageToArmor;
        if (equippedArmor.armorHealth <= 0)
        {
            UnequipArmor();
        }

        if (isUsingArmor)
        {
            int currentArmorHealth = equippedArmor.armorHealth;
            targetArmorFillAmount = (float)currentArmorHealth / maxArmorHealth;
            armorText.text = $"{currentArmorHealth}/{maxArmorHealth}";
        }
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

    public void EquipArmor(ArmorInfo armorInfo)
    {
        equippedArmor = armorInfo;
        isUsingArmor = true;

        maxArmorHealth = armorInfo.armorHealth;

        armorUIParent.SetActive(true);

        targetArmorFillAmount = 1f;
        armorBarImage.color = Global.DamageTypeToColor(armorInfo.armorType);

        armorText.text = $"{armorInfo.armorHealth}/{maxArmorHealth}";
    }

    public void UnequipArmor()
    {
        equippedArmor = new ArmorInfo();
        isUsingArmor = false;

        armorUIParent.SetActive(false);
    }
}
