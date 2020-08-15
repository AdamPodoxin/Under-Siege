using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusValuePopupText : MonoBehaviour
{
    private Text text;
    private Animator animator;

    private void Awake()
    {
        text = GetComponent<Text>();
        animator = GetComponent<Animator>();
    }

    public void ShowText(string displayString, Color color)
    {
        gameObject.SetActive(true);
        animator.Play("StatusValuePopupText_Show", -1, 0f);

        text.text = displayString;
        text.color = color;
    }

    public void FinishAnimation()
    {
        gameObject.SetActive(false);
    }
}
