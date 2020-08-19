using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public enum Affinity { Warrior, Assassin, Ranger, Sorcerer };

    public enum DamageType { Physical, Magic };

    public static Color DamageTypeToColor(DamageType damageType)
    {
        return damageType.Equals(DamageType.Physical) ? Color.red : new Color(130f / 255f, 0f, 120f / 130f);
    }
}

[System.Serializable]
public struct DamageInfo
{
    public int damage;
    public Global.DamageType damageType;

    public DamageInfo(int damage, Global.DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
    }
}

[System.Serializable]
public struct ArmorInfo
{
    public int armorHealth;
    public float resistPercent;
    public Global.DamageType armorType;

    public ArmorInfo(int armorHealth, float resistPercent, Global.DamageType armorType)
    {
        this.armorHealth = armorHealth;
        this.resistPercent = resistPercent;
        this.armorType = armorType;
    }
}
