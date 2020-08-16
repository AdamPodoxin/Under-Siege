using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public int health = 40;
    private int maxHealth;

    public int damage = 2;
    public GlobalEnums.DamageType damageType;
    public float attackTime = 1.2f;
    public float walkSpeed = 2.6f;

    public bool IsAttackingTarget { get; set; }
    public bool IsFollowingTarget { get; set; }
    protected bool isDead = false;

    protected string state = "Idle";
    protected readonly string[] states = { "Idle", "Walk", "Attack" };

    protected Component target;

    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    [Space]

    public Image healthBarImage;
    public StatusValuePopupText statusValuePopupText;

    protected void Start()
    {
        maxHealth = health;

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsFollowingTarget)
        {
            transform.Translate((target.transform.position - transform.position).normalized * walkSpeed * Time.deltaTime);
        }
    }

    protected IEnumerator AttackCoroutine()
    {
        if (!isDead && target != null && !IsAttackingTarget)
        {
            IsAttackingTarget = true;
            animator.Play("Attack", -1, 0f);

            yield return new WaitForSeconds(attackTime);

            if (state.Equals("Attack") && !isDead && target != null && !IsAttackingTarget)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    public void FinishAttackAnimation()
    {
        IsAttackingTarget = false;
    }

    protected void SetState(string newState)
    {
        if (!isDead)
        {
            state = newState;
            animator.Play(newState, -1, 0f);
        }
    }

    protected void SetDeathState()
    {
        state = "Dead";
        animator.Play(state, -1, 0f);
    }

    public void FinishDeathAnimation()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        if (!isDead)
        {
            health -= damageInfo.damage;

            if (health <= 0)
            {
                health = 0;
                Die();
            }

            healthBarImage.fillAmount = (float)health / maxHealth;
            statusValuePopupText.ShowText($"-{damageInfo.damage}", Color.red);
        }
    }

    public void Die()
    {
        StopAllCoroutines();
        isDead = true;

        StopWalk();
        StopAttack();

        SetDeathState();

        print(name + " died");
    }

    public void AttackTarget()
    {
        if (target != null)
            target.SendMessage("TakeDamage", new DamageInfo(damage, damageType));
    }

    public void SetTarget(Component targetComponent)
    {
        if (!isDead)
        {
            target = targetComponent;
        }
    }

    public void StartAttack()
    {
        if (!isDead)
        {
            StopWalk();

            SetState("Attack");

            spriteRenderer.flipX = target.transform.position.x > transform.position.x;

            StartCoroutine(AttackCoroutine());
        }
    }

    public void StopAttack()
    {
        IsAttackingTarget = false;
        StopCoroutine(AttackCoroutine());
        StartWalk();
    }

    public void StartWalk()
    {
        if (!isDead)
        {
            IsFollowingTarget = true;
            SetState("Walk");
        }
    }

    public void StopWalk()
    {
        IsFollowingTarget = false;
        SetState("Idle");
    }
}
