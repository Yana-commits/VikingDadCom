using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantDestructable : Destructable
{
    public Action OnDie;
    public Action<Vector3> OnShowSphere;
    public Action<int> OnMutantHealth;
    public override void Die()
    {
        base.Die();
        OnDie?.Invoke();
        StartCoroutine(DieActions());
    }

    public override void Hit(int damage)
    {
        base.Hit(damage);
        OnMutantHealth?.Invoke(Health);
    }
    private IEnumerator DieActions()
    {
        yield return new WaitForSeconds(5f);

        this.gameObject.SetActive(false);
        OnShowSphere?.Invoke(this.gameObject.transform.position);
    }
}
