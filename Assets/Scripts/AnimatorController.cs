using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public GameObject test;
    [Header("Terpsichora")]
    public GameObject terpsichora;
    private AnimationController terpsichoraAnimationController;
    [Header("Character")]
    public GameObject character;
    private AnimationController characterAnimationController;
    [Header("Current Animation")]
    public string currentAnimationName;
    public State currentStateSkill;
    public SkillScriptableObject currentSkillScriptableObject;
    

    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    private PlayerController playerController;
    //public int currentAnimationframe;

    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        terpsichoraAnimationController = terpsichora.GetComponent<AnimationController>();
        characterAnimationController = character.GetComponent<AnimationController>();
        playerController = GetComponent<PlayerController>();
        playerScriptableObject = playerController.playerScriptableObject;
    }
    public void Start()
    {
        character.transform.parent = terpsichora.transform;
    }
    private void Update()
    {
        
        currentAnimationName = GetCurrentAnimationName(); 
    }
    public void PlayAnimations(string name)
    {
        switch (name)
        {
            case "Idle":
                characterAnimationController.PlayAnimation("C_Idle");
                terpsichoraAnimationController.PlayAnimation("T_Idle");
                break;
            case "Slash0":
                characterAnimationController.PlayAnimation("C_Slash0");
                terpsichoraAnimationController.PlayAnimation("T_Slash0"); 
                break;
            case "Slash1":
                characterAnimationController.PlayAnimation("C_Slash1");
                terpsichoraAnimationController.PlayAnimation("T_Slash1");
                break;
            case "Slash2":
                characterAnimationController.PlayAnimation("C_Slash2");
                terpsichoraAnimationController.PlayAnimation("T_Slash2");
                break;
            case "FrontDash":
                characterAnimationController.PlayAnimation("C_FrontDash");
                terpsichoraAnimationController.PlayAnimation("T_FrontDash");
                break;
        }
    }
    
    public string GetCurrentAnimationName()
    {
        if (currentSkillScriptableObject == null)
        {
            return "Error";
        }
        else
        {
            return currentSkillScriptableObject.name;
        }
    }
    
}
