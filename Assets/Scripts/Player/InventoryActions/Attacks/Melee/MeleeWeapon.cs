using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PlayerInventoryAction
{
    public MeleeWeaponStats stats;

    private Animator animator, swipeAnimator;
    private GameObject childObject, swipeObject;

    private PlayerCombat playerCombat;

    private int weaponIndex;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        childObject = transform.GetChild(0).gameObject;

        swipeObject = GameObject.Find("Melee_Swipe");
        swipeAnimator = swipeObject.GetComponent<Animator>();

        playerCombat = FindObjectOfType<PlayerCombat>();

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

    public void FinishAnimation()
    {
        childObject.SetActive(false);
        swipeObject.SetActive(false);
    }

    private IEnumerator UseCoroutine()
    {
        yield return new WaitForSeconds(stats.castTime);
        playerCombat.FinishAttack(weaponIndex);
    }
}
