using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "ScriptableObjects/Player/Actions/Weapons/Melee")]
public class MeleeWeaponStats : ScriptableObject
{
    public GlobalEnums.Affinity affinity;
    public GlobalEnums.ActionPriority priority;

    public new string name;
    public string description;

    public int damage;
    public float castTime;

    public int level = 1;
    public int cost = 0;
    public float length = 1.5f;
}
