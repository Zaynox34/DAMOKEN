using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AttackScriptableObject", menuName = "ScriptableObjects/Attack")]
public class AttackScriptableObject : SkillScriptableObject
{
    [field: SerializeField, Range(min: 0, max: 100), Tooltip("description")]
    public int attackDamage { get; private set; } = 100;
   [field: SerializeField]
    public List<List<Transform>> hitboxColider;

    [field: SerializeField]
    public int skillOnBlockTime { get; private set; } = 10;
}
