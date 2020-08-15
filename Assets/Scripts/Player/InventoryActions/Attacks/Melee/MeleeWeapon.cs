using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PlayerInventoryAction
{
    public MeleeWeaponStats stats;

    private Animator animator, swipeAnimator;
    private GameObject childObject, swipeObject;

    private PlayerCombat playerCombat;
    private PlayerStats playerStats;

    private int weaponIndex;
    private int damage;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        childObject = transform.GetChild(0).gameObject;

        swipeObject = GameObject.Find("Melee_Swipe");
        swipeAnimator = swipeObject.GetComponent<Animator>();
        swipeObject.transform.localPosition = new Vector2(swipeObject.transform.localPosition.x, stats.length);

        playerCombat = FindObjectOfType<PlayerCombat>();

        playerStats = FindObjectOfType<PlayerStats>();
        if (stats.affinity.Equals(GlobalEnums.Affinity.Warrior) && playerStats.affinity.Equals(GlobalEnums.Affinity.Warrior))
        {
            damage = playerStats.affinityLevel - 1 + stats.damage;
        }

        weaponIndex = stats.priority.Equals(GlobalEnums.ActionPriority.Primary) ? 0 : 1;
    }

    public override void Use()
    {
        base.Use();

        childObject.SetActive(true);
        swipeObject.SetActive(true);
        playerCombat.CanAct = false;

        animator.Play("Attack");
        swipeAnimator.Play("Melee_Swipe");

        StartCoroutine(UseCoroutine());
    }

    private IEnumerator UseCoroutine()
    {
        yield return new WaitForSeconds(stats.castTime);
        playerCombat.FinishAttack(weaponIndex);
    }

    public void FinishAnimation()
    {
        childObject.SetActive(false);
        swipeObject.SetActive(false);
    }

    public void CollisionWithEnemy(Collider2D collision)
    {
        print(collision);
    }
}
