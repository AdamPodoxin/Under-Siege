using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerInventoryAction[] playerAttacks;
    public PlayerInventoryAction[] playerAbilities;
    public PlayerInventoryAction[] playerItems;

    public void UseAttack(int index)
    {
        playerAttacks[index].Use();

    }

    public void UseAbility(int index)
    {
        playerAbilities[index].Use();
    }

    public void UseItem(int index)
    {
        playerItems[index].Use();
    }
}
