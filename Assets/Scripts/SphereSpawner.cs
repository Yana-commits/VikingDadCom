using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private LifeSfere lifeSfere;
    [SerializeField] private int numberOfSferes;

    private List<LifeSfere> lifeSferes = new List<LifeSfere>();

    public void SphereCreate(Vector3 position)
    {
        var newMutant = lifeSferes.Where(x => !x.gameObject.activeInHierarchy).FirstOrDefault();

        if (newMutant != null)
        {
            newMutant.transform.position = position;
            newMutant.gameObject.SetActive(true);
        }
        else if (lifeSferes.Count <= numberOfSferes)
        {
            var mutant = Instantiate(lifeSfere, position + new Vector3(0f,1f,0f), Quaternion.identity);
            lifeSferes.Add(mutant);
        }
    }
}
