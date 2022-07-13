using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private int damage = 1;

    public int Damage { get => damage; set => damage = value; }

    private void OnTriggerEnter(Collider other)
    {
       
        var owner = this.gameObject.GetComponent<MutantController>();

        if (other.TryGetComponent<MutantDestructable>(out MutantDestructable mutant) && owner ==null)
        {
           
            mutant.Hit(Damage);
        }
        else if (other.TryGetComponent<PlayerDestructable>(out PlayerDestructable player))
        {
            player.Hit(Damage);
        }
    }
}
