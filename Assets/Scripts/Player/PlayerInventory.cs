using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public PlayerInventoryAction[] playerAttacks;
    public PlayerInventoryAction[] playerAbilities;
    public PlayerInventoryAction[] playerItems;

    private void Start()
    {
        playerAttacks[0].ActionIndex = 0;
        playerAttacks[1].ActionIndex = 1;

        playerAbilities[0].ActionIndex = 0;
        playerAbilities[1].ActionIndex = 1;

        playerItems[0].ActionIndex = 0;
        playerItems[1].ActionIndex = 1;
    }

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
