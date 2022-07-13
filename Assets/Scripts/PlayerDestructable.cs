using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestructable : Destructable
{
    public Action OnPlayerDie;
    public Action<int> OnHealth;
    public override void Die()
    {
        base.Die();
        OnPlayerDie?.Invoke();
    }

    public override void Hit(int damage)
    {
        base.Hit(damage);
        OnHealth?.Invoke(Health);
    }

    public void PlusHealth()
    {
        Health++;
        OnHealth?.Invoke(Health);
    }
}
