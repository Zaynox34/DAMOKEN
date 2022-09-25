using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerScriptableObject",menuName ="ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    public PlayerControls playerControls;
    [field: SerializeField, Range(min: 0, max: 100), Tooltip("description")]
    public int health { get; private set; } = 100;
    [field: SerializeField]
    public float speed { get; private set; } = 10;
    [field: SerializeField]
    public SkillScriptableObject start;
    [field: SerializeField]
    public SkillScriptableObject idle;
    [field: SerializeField]
    public SkillScriptableObject walkFront;
    [field: SerializeField]
    public SkillScriptableObject walkBack;
    [field: SerializeField]
    public SkillScriptableObject dashFront;
    [field: SerializeField]
    public SkillScriptableObject dashBack;
    [field: SerializeField]
    public SkillScriptableObject garde;
    [field: SerializeField]
    public SkillScriptableObject ko;

    [field: SerializeField]
    public AttackScriptableObject slash0;
    [field: SerializeField]
    public AttackScriptableObject slash1;
    [field: SerializeField]
    public AttackScriptableObject slash2;
    


    /*[field: SerializeField]
    public AttackScriptableObject special0;
    [field: SerializeField]
    public AttackScriptableObject special1;
    [field: SerializeField]
    public AttackScriptableObject special2;
    */
}
