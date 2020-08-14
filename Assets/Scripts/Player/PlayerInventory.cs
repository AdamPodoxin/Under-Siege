using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{


    public void UseAttack(int index)
    {
        print("Use attack " + index);
    }

    public void UseAbility(int index)
    {
        print("Use ability " + index);
    }

    public void UseItem(int index)
    {
        print("Use item " + index);
    }
}
