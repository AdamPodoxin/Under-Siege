using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool CanAct { get; set; } = true;

    private Vector2 facingDirection;
    public Vector2 FacingDirection { get { return facingDirection; } }

    private PlayerInventory playerInventory;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (CanAct)
            {
                if (Input.GetAxisRaw("Primary Attack") >= 1f)
                {
                    PrimaryAttack();
                }
                else if (Input.GetAxisRaw("Secondary Attack") >= 1f)
                {
                    SecondaryAttack();
                }

                if (Input.GetAxisRaw("Primary Ability") >= 1f)
                {
                    PrimaryAbility();
                }
                else if (Input.GetAxisRaw("Secondary Ability") >= 1f)
                {
                    SecondaryAbility();
                }

                if (Input.GetAxisRaw("Primary Item") >= 1f)
                {
                    PrimaryItem();
                }
                else if (Input.GetAxisRaw("Secondary Item") >= 1f)
                {
                    SecondaryItem();
                }
            }
        }
    }

    private void PrimaryAttack()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseAttack(0);
    }

    private void SecondaryAttack()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseAttack(1);
    }

    private void PrimaryAbility()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseAbility(0);
    }

    private void SecondaryAbility()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseAbility(1);
    }

    private void PrimaryItem()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseItem(0);
    }

    private void SecondaryItem()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

        playerInventory.UseItem(1);
    }
}
