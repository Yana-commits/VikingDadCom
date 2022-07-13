using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Run(float movement)
    {
        animator.SetFloat("Speed", movement);
    }
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
    public void Damage()
    {
        animator.SetTrigger("Damage");
    }
    public void Die()
    {
        animator.SetTrigger("Die");
    }
}
