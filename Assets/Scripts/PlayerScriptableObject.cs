using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerScriptableObject",menuName ="ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    public PlayerControls playerControls;
    public InputDevice ControlsSchemes;
    [field: SerializeField, Range(min: 0, max: 100), Tooltip("description")]
    public int health { get; private set; } = 100;
    [field: SerializeField]
    public float speed { get; private set; } = 10;

    public List<SkillScriptableObject> listSkillScript;

}
