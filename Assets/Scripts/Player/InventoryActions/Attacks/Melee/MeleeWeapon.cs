using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : PlayerInventoryAction
{
    public MeleeWeaponStats stats;

    protected Animator animator, swipeAnimator;
    protected GameObject childObject, swipeObject;

    protected PlayerCombat playerCombat;
    protected PlayerStats playerStats;

    protected int damage;

    protected void OnEnable()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (childObject == null)
            childObject = transform.GetChild(0).gameObject;

        if (swipeObject == null)
        {
            swipeObject = GameObject.Find("Melee_Swipe");
            swipeAnimator = swipeObject.GetComponent<Animator>();
            swipeObject.transform.localPosition = new Vector2(swipeObject.transform.localPosition.x, stats.length);
        }

        if (playerCombat == null)
            playerCombat = FindObjectOfType<PlayerCombat>();

        if (playerStats == null)
        {
            playerStats = FindObjectOfType<PlayerStats>();

            damage = stats.damage;
            if (stats.affinity.Equals(Global.Affinity.Warrior) && playerStats.affinity.Equals(Global.Affinity.Warrior))
                damage += Mathf.RoundToInt(Mathf.Pow(playerStats.affinityLevel - 1, 1.2f));
        }
    }

    public override void Use()
    {
        base.Use();

        childObject.SetActive(true);
        swipeObject.SetActive(true);
        playerCombat.CanAct = false;

        animator.Play("Attack", -1, 0f);
        swipeAnimator.Play("Melee_Swipe", -1, 0f);

        StartCoroutine(UseCoroutine());
    }

    protected IEnumerator UseCoroutine()
    {
        yield return new WaitForSeconds(stats.castTime);
        playerCombat.FinishAttack(ActionIndex);
    }

    public void FinishAnimation()
    {
        childObject.SetActive(false);
        swipeObject.SetActive(false);
    }

    public void CollisionWithEnemy(Collider2D collision)
    {
        collision.GetComponent<BasicEnemy>().TakeDamage(new DamageInfo(damage, stats.damageType));
    }
}
