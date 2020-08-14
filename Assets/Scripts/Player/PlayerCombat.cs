using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public bool CanAttack { get; set; } = true;

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
        print("PrimaryAttack");
    }

    private void SecondaryAttack()
    {
        print("SecondaryAttack");
    }

    private void PrimaryAbility()
    {
        print("PrimaryAbility");
    }

    private void SecondaryAbility()
    {
        print("SecondaryAbility");
    }

    private void PrimaryItem()
    {
        print("PrimaryItem");
    }

    private void SecondaryItem()
    {
        print("SecondaryItem");
    }
}
