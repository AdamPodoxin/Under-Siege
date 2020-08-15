using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeCollider : MonoBehaviour
{
    private BasicEnemy parent;

    private void Awake()
    {
        parent = transform.GetComponentInParent<BasicEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            parent.SetTarget(collision.GetComponent<PlayerStats>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            parent.SetTarget(null);
        }
    }
}
