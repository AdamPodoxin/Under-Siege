using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public enum Affinity { Warrior, Assassin, Ranger, Sorcerer };

    public enum DamageType { Physical, Magical, Inevitable };

    private static readonly Color[] damageTypeColors = { Color.red, new Color(130f / 255f, 0f, 120f / 130f), new Color(210f / 255f, 155f / 255f, 30f / 255f) };

    public static Color DamageTypeToColor(DamageType damageType)
    {
        return damageTypeColors[(int)damageType];
    }

    public static bool CompareDamageTypes(DamageType a, DamageType b)
    {
        return a.Equals(DamageType.Inevitable) || b.Equals(DamageType.Inevitable) || a.Equals(b);
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
