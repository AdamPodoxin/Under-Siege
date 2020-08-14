using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool CanAttack { get; set; } = true;

    private PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (CanAttack)
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
        playerInventory.UseAttack(0);
    }

    private void SecondaryAttack()
    {
        playerInventory.UseAttack(1);
    }

    private void PrimaryAbility()
    {
        playerInventory.UseAbility(0);
    }

    private void SecondaryAbility()
    {
        playerInventory.UseAbility(1);
    }

    private void PrimaryItem()
    {
        playerInventory.UseItem(0);
    }

    private void SecondaryItem()
    {
        playerInventory.UseItem(1);
    }
}
