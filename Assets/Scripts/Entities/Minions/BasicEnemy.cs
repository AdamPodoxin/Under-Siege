using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public int health = 40;
    private int maxHealth;

    public int damage = 2;
    public float attackTime = 1.2f;

    public bool InRangeOfTarget { get; set; }
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

    protected IEnumerator AttackCoroutine()
    {
        if (!isDead && target != null)
        {
            animator.Play("Attack", -1, 0f);

            yield return new WaitForSeconds(attackTime);

            if (state.Equals("Attack") && !isDead)
            {
                StartCoroutine(AttackCoroutine());
            }
        }
    }

    protected void SetState(string newState)
    {
        state = newState;
        animator.Play(newState, -1, 0f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            Die();
        }

        healthBarImage.fillAmount = (float)health / maxHealth;
        statusValuePopupText.ShowText($"-{damage}", Color.red);
    }

    public void Die()
    {
        StopAllCoroutines();
        isDead = true;

        print(name + " died");
    }

    public void AttackTarget()
    {
        if (target != null)
            target.SendMessage("TakeDamage", damage);
    }

    public void SetTarget(Component targetComponent)
    {
        if (!isDead)
        {
            target = targetComponent;

            if (targetComponent == null)
            {
                InRangeOfTarget = false;
                SetState("Idle");

                StopCoroutine(AttackCoroutine());
            }
            else
            {
                InRangeOfTarget = true;
                SetState("Attack");

                spriteRenderer.flipX = targetComponent.transform.position.x > transform.position.x;

                StartCoroutine(AttackCoroutine());
            }
        }
    }
}
