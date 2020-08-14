using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject[] attacks;
    public GameObject[] abilities;
    public GameObject[] items;

    public bool CanAct { get; set; } = true;

    [SerializeField] private Vector2 facingDirection;
    public Vector2 FacingDirection { get { return facingDirection; } }

    private PlayerInventory playerInventory;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
        playerMovement = GetComponent<PlayerMovement>();

        foreach (GameObject o in attacks)
        {
            o.SetActive(true);
            o.SetActive(false);
        }
        foreach (GameObject o in abilities)
        {
            o.SetActive(true);
            o.SetActive(false);
        }
        foreach (GameObject o in items)
        {
            o.SetActive(true);
            o.SetActive(false);
        }
    }

    private void Update()
    {
        if (!playerMovement.MovementDirection.Equals(Vector2.zero))
            facingDirection = playerMovement.MovementDirection;

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

    private void UseAction(GameObject action, Vector3 eulerAngles)
    {
        action.SetActive(true);
        action.transform.eulerAngles = eulerAngles;
    }

    public void FinishAttack(int index)
    {
        attacks[index].SetActive(false);
        CanAct = true;
    }

    private Vector3 CalculateEulerAnglesFromDirection(Vector2 direction)
    {
        float angle = 0f;

        direction = RoundVector2(direction);

        if (direction.Equals(Vector2.up))
            angle = 0f;
        else if (direction.Equals(Vector2.left))
            angle = 90f;
        else if (direction.Equals(Vector2.down))
            angle = 180f;
        else if (direction.Equals(Vector2.right))
            angle = 270f;

        else if (direction.Equals(new Vector2(-1f, 1f)))
            angle = 45f;
        else if (direction.Equals(new Vector2(-1f, -1f)))
            angle = 135f;
        else if (direction.Equals(new Vector2(1f, -1f)))
            angle = 225f;
        else if (direction.Equals(new Vector2(1f, 1f)))
            angle = 315f;

        return Vector3.forward * angle;
    }

    private Vector2 RoundVector2(Vector2 vector)
    {
        float x = Mathf.RoundToInt(vector.x);
        float y = Mathf.RoundToInt(vector.y);

        return new Vector2(x, y);
    }

    private void PrimaryAttack()
    {
        UseAction(attacks[0], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseAttack(0);
    }

    private void SecondaryAttack()
    {
        UseAction(attacks[1], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseAttack(1);
    }

    private void PrimaryAbility()
    {
        UseAction(abilities[0], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseAbility(0);
    }

    private void SecondaryAbility()
    {
        UseAction(abilities[1], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseAbility(1);
    }

    private void PrimaryItem()
    {
        UseAction(items[0], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseItem(0);
    }

    private void SecondaryItem()
    {
        UseAction(items[1], CalculateEulerAnglesFromDirection(facingDirection));
        playerInventory.UseItem(1);
    }
}
