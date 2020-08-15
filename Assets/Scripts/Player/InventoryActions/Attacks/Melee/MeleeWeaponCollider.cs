using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponCollider : MonoBehaviour
{
    private MeleeWeapon parent;

    private void Awake()
    {
        parent = transform.GetComponentInParent<MeleeWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            parent.CollisionWithEnemy(collision);
        }
    }
}
