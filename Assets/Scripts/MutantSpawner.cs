using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MutantSpawner : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private MutantController mutantPrefab;
    [SerializeField] private float distance;
    [SerializeField] private float spawnTime;
    [SerializeField] private float numberOfMutant;

    private float time = 0;
    private List<MutantController> mutants = new List<MutantController>();
    private GameMode gameMode = GameMode.None;

    public Action mutantAction;
    public Action<Vector3> sphereAction;

    public GameMode GameMode { get => gameMode; set => gameMode = value; }

    void Update()
    {
        if (GameMode == GameMode.Play)
        {
            time += Time.deltaTime;

            if (time >= spawnTime)
            {
                MutantCreate();
                time = 0;
            }
        }
    }

    public void Init(GameMode _gameMode,Action _action,Action<Vector3> _sphereAction)
    {
        GameMode = _gameMode;
        mutantAction = _action;
        sphereAction = _sphereAction;
    }
    public void MutantCreate()
    {
        Vector3 mutantPos = target.transform.position +
                new Vector3(Random.value - 0.5f, 0.1f, Random.value - 0.5f).normalized * distance * 10;

        var newMutant = mutants.Where(x => !x.gameObject.activeInHierarchy).FirstOrDefault();

        if (newMutant != null)
        {
            newMutant.transform.position = mutantPos;
            newMutant.RepeatInit(true);
            newMutant.gameObject.SetActive(true);
        }
        else if(mutants.Count < numberOfMutant)
        {
            var mutant = Instantiate(mutantPrefab, mutantPos, Quaternion.identity);
            mutant.Target = target;
            mutant.mutantDestructable.OnDie += mutantAction;
            mutant.mutantDestructable.OnShowSphere += sphereAction;
            mutants.Add(mutant);
        }
    }
}
