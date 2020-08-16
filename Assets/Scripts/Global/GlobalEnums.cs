using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnums : MonoBehaviour
{
    public enum Affinity { Warrior, Assassin, Ranger, Sorcerer };
    public enum ActionPriority { Primary, Secondary };

    public enum DamageType { Physical, Magic };
}

[System.Serializable]
public struct DamageInfo
{
    public int damage;
    public GlobalEnums.DamageType damageType;

    public DamageInfo(int damage, GlobalEnums.DamageType damageType)
    {
        this.damage = damage;
        this.damageType = damageType;
    }
}
