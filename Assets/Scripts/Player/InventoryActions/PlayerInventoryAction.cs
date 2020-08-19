using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryAction : MonoBehaviour
{
    public int ActionIndex { get; set; }

    public virtual void Use() { }
}
