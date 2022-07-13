using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MutantSettings", menuName = "ScriptableObjects/MutantSettings", order = 1)]
public class MutantSettings : ScriptableObject
{
    public float speed = 4f;
    public float attackDistance = 1f;
    public int damage = 1;
}
