using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public GameObject test;
    [Header("Terpsichora")]
    [SerializeField]
    private GameObject terpsichora;
    private AnimationController terpsichoraAnimationController;
    [Header("Character")]
    [SerializeField]
    private GameObject character;
    private AnimationController characterAnimationController;
    [Header("Current Animation")]
    public string currentAnimationName;
    //public int currentAnimationframe;

    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
        terpsichoraAnimationController = terpsichora.GetComponent<AnimationController>();
        characterAnimationController = character.GetComponent<AnimationController>();
    }
    public void Start()
    {
        character.transform.parent = terpsichora.transform;
    }
    private void Update()
    {
        currentAnimationName = GetCurrentAnimationName();
        /*
        if(currentAnimationName!="Idle")
        {
            character.transform.parent = transform;
        }
        else
        {
            character.transform.parent = terpsichora.transform;
        }
        */
        
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
        }
        //animator.SetTrigger(name);
    }
    
    public string GetCurrentAnimationName()
    {
        if(terpsichoraAnimationController.currentAnimationName == "T_Idle" &&
            characterAnimationController.currentAnimationName == "C_Idle")
        {
            return "Idle";
        }
        if (terpsichoraAnimationController.currentAnimationName == "T_Slash0" &&
            characterAnimationController.currentAnimationName == "C_Slash0")
        {
            return "Slash0";
        }
        if (terpsichoraAnimationController.currentAnimationName == "T_Slash1" &&
            characterAnimationController.currentAnimationName == "C_Slash1")
        {
            return "Slash1";
        }
        if (terpsichoraAnimationController.currentAnimationName == "T_Slash2" &&
            characterAnimationController.currentAnimationName == "C_Slash2")
        {
            return "Slash2";
        }
        else
        {
            Debug.Log("Errro Grave");
            return "Error";
        }

    }
}
