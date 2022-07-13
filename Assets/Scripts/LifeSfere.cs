using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSfere : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerDestructable>(out PlayerDestructable player))
        {
            player.PlusHealth();

            this.gameObject.SetActive(false);
        }
    }

}
