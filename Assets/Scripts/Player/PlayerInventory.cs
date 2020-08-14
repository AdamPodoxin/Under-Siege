﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerInventoryAction[] playerAttacks;
    public PlayerInventoryAction[] playerAbilities;
    public PlayerInventoryAction[] playerItems;

    public void UseAttack(int index)
    {
        try
        {
            playerAttacks[index].Use();
        }
        catch { }

        print("Use attack " + index);
    }

    public void UseAbility(int index)
    {
        try
        {
            playerAbilities[index].Use();
        }
        catch { }

        print("Use ability " + index);
    }

    public void UseItem(int index)
    {
        try
        {
            playerItems[index].Use();
        }
        catch { }

        print("Use item " + index);
    }
}