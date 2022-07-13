using UnityEngine;

public class Destructable : MonoBehaviour, IDestructable
{
    [SerializeField] protected CreatureAnimator animator;

    protected int health = 1;
    protected bool isDie = true;
    public int Health { get => health; set => health = value; }
    public bool IsDie { get => isDie; set => isDie = value; }

    public virtual void Die()
    {
        animator.Die();

    }

    public virtual void Hit(int damage)
    {
        if (IsDie)
        {
            animator.Damage();
            Health -= damage;

            if (Health <= 0)
            {
                IsDie = false;
                Die();
            }
        }
    }
}
