using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public static bool canPlayerMove = true;

    private bool hasStuffHappenedAlready = false;
    private Animator animator;

    private void Start()
    {
        animator = GameObject.Find("Boulder").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasStuffHappenedAlready && gameObject.name == "Pressure Plate")
        {
            canPlayerMove = false;
            animator.Play("Boulder Roll Down");
        }
    }

    public void AnimationEnd()
    {
        PressurePlate.canPlayerMove = true;
    }
}
