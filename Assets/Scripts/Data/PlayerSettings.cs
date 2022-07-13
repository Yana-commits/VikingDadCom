using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/CaPlayerSettings", order = 1)]
public class PlayerSettings : ScriptableObject
{
    public float speed = 5f;
    public float lookSensetivity = 3f;
    public int health = 20;
    public int damage =1;
}
