using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PlayerInventoryAction
{
    public MeleeWeaponStats stats;

    private Animator animator;
    private GameObject childObject;

    private PlayerCombat playerCombat;

    private int weaponIndex;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        childObject = transform.GetChild(0).gameObject;

        playerCombat = FindObjectOfType<PlayerCombat>();

        weaponIndex = stats.priority.Equals(GlobalEnums.ActionPriority.Primary) ? 0 : 1;
    }

    public override void Use()
    {
        base.Use();

        childObject.SetActive(true);
        playerCombat.CanAct = false;

        animator.Play("Attack");

        StartCoroutine(UseCoroutine());
    }

    public void FinishAnimation()
    {
        childObject.SetActive(false);
    }

    private IEnumerator UseCoroutine()
    {
        yield return new WaitForSeconds(stats.castTime);
        playerCombat.FinishAttack(weaponIndex);
    }
}
