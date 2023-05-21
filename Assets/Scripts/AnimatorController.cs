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
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                //characterAnimationController.PlayAnimation("C_Idle");
                //terpsichoraAnimationController.PlayAnimation("T_Idle");
                break;
            case "Slash0":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_Slash0");
                terpsichoraAnimationController.PlayAnimation("T_Slash0");
                break;
            case "Slash1":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_Slash1");
                terpsichoraAnimationController.PlayAnimation("T_Slash1");
                break;
            case "Slash2":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_Slash2");
                terpsichoraAnimationController.PlayAnimation("T_Slash2");
                break;
            case "FrontDash":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_FrontDash");
                terpsichoraAnimationController.PlayAnimation("T_FrontDash");
                break;
            case "BackDash":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_BackDash");
                terpsichoraAnimationController.PlayAnimation("T_BackDash");
                break;
            case "FrontWalk":
                /*
                characterAnimationController.ResetAnimation("C_Slash0");
                terpsichoraAnimationController.ResetAnimation("T_Slash0");
                characterAnimationController.ResetAnimation("C_Slash1");
                terpsichoraAnimationController.ResetAnimation("T_Slash1");
                characterAnimationController.ResetAnimation("C_Slash2");
                terpsichoraAnimationController.ResetAnimation("T_Slash2");
                characterAnimationController.ResetAnimation("C_FrontDash");
                terpsichoraAnimationController.ResetAnimation("T_FrontDash");
                characterAnimationController.ResetAnimation("C_BackDash");
                terpsichoraAnimationController.ResetAnimation("T_BackDash");*/
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", true);
                break;
            case "BackWalk":
                /*
                characterAnimationController.ResetAnimation("C_Slash0");
                terpsichoraAnimationController.ResetAnimation("T_Slash0");
                characterAnimationController.ResetAnimation("C_Slash1");
                terpsichoraAnimationController.ResetAnimation("T_Slash1");
                characterAnimationController.ResetAnimation("C_Slash2");
                terpsichoraAnimationController.ResetAnimation("T_Slash2");
                characterAnimationController.ResetAnimation("C_FrontDash");
                terpsichoraAnimationController.ResetAnimation("T_FrontDash");
                characterAnimationController.ResetAnimation("C_BackDash");
                terpsichoraAnimationController.ResetAnimation("T_BackDash");*/
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation2("IsBackWalk", true);
                break;
            case "Cancel":
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                characterAnimationController.PlayAnimation("C_Cancel");
                terpsichoraAnimationController.PlayAnimation("T_Cancel");
                break;
            case "Shake":
                /*
                characterAnimationController.ResetAnimation("C_Slash0");
                terpsichoraAnimationController.ResetAnimation("T_Slash0");
                characterAnimationController.ResetAnimation("C_Slash1");
                terpsichoraAnimationController.ResetAnimation("T_Slash1");
                characterAnimationController.ResetAnimation("C_Slash2");
                terpsichoraAnimationController.ResetAnimation("T_Slash2");
                characterAnimationController.ResetAnimation("C_FrontDash");
                terpsichoraAnimationController.ResetAnimation("T_FrontDash");
                characterAnimationController.ResetAnimation("C_BackDash");
                terpsichoraAnimationController.ResetAnimation("T_BackDash");
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);*/
                characterAnimationController.PlayAnimation2("IsStun", true);
                break;
            case "DeShake":
                /*
                characterAnimationController.ResetAnimation("C_Slash0");
                terpsichoraAnimationController.ResetAnimation("T_Slash0");
                characterAnimationController.ResetAnimation("C_Slash1");
                terpsichoraAnimationController.ResetAnimation("T_Slash1");
                characterAnimationController.ResetAnimation("C_Slash2");
                terpsichoraAnimationController.ResetAnimation("T_Slash2");
                characterAnimationController.ResetAnimation("C_FrontDash");
                terpsichoraAnimationController.ResetAnimation("T_FrontDash");
                characterAnimationController.ResetAnimation("C_BackDash");
                terpsichoraAnimationController.ResetAnimation("T_BackDash");
                characterAnimationController.PlayAnimation2("IsBackWalk", false);
                characterAnimationController.PlayAnimation2("IsFrontWalk", false);
                */
                characterAnimationController.PlayAnimation2("IsStun", false);

                break;
        }
    }
    public void Pause()
    {
        characterAnimationController.Pause();
        terpsichoraAnimationController.Pause();
    }
    public void DePause()
    {
        characterAnimationController.DePause();
        terpsichoraAnimationController.DePause();
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
    public SkillScriptableObject GetCurrentSkill()
    {
        return currentSkillScriptableObject;
    }
    public bool PeutCanceler(SkillScriptableObject Canceleur)
    {
        return GetCurrentSkill().isCancelable(Canceleur, currentStateSkill);
    }
}
