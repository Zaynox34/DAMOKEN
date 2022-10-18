using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject character;
    public GameObject player;
    private PlayerController playerController;
    private AnimatorController animatorController;
    private Animator animator;
    public AnimatorStateInfo currentAnimatorStateInfo;
    public AnimationClip currentAnimationClip;
    public string currentAnimationName;
    public int currentAnimationFrame;
    public bool isActiveState;
    //public int a;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
        animatorController = player.GetComponent<AnimatorController>();
        isActiveState = false;
        a = 0;
    }
    public void ActiveStateEnable()
    {
        isActiveState = true;
    }
    public void ActiveStateDisable()
    {
        isActiveState = false;
    }
    public void TrueGetInfoAnimation()//la vrai get info
    {
        currentAnimationClip = animator.GetCurrentAnimatorClipInfo(default)[0].clip;
        currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        currentAnimationName = currentAnimationClip.name;
        currentAnimationFrame = (int)
            (currentAnimatorStateInfo.normalizedTime *
            (currentAnimationClip.length *
            currentAnimationClip.frameRate));
        if (this.gameObject == animatorController.character)
        {
            GetSkill();
            WhatISYourState();
            /*
            if (currentAnimationName == "C_FrontDash")
            {
                a++;
                Debug.Log(this.gameObject + " // " + a + " // " + currentAnimationFrame + " // " +
                    currentAnimationClip + " // " + animatorController.currentStateSkill);
            }
            */
        }
    }
    public void GetInfoAnimation()// a renomer Animation Update
    {
        TrueGetInfoAnimation();

        LaMagie();
    }
    public void GetSkill()
    {
        int i=0;
        if (currentAnimationName == "C_Idle")
        {
            i = 0;
        }
        else
        {
            if (currentAnimationName == "C_Slash0")
            {
                i = 1;
            }
            else
            {
                if (currentAnimationName == "C_Slash1")
                {
                    i = 2;
                }
                else
                {
                    if (currentAnimationName == "C_Slash2")
                    {
                        i = 3;
                    }
                    else
                    {
                        if (currentAnimationName == "C_FrontDash")
                        {
                            i = 4;
                            
                        }
                    }
                }
            }
        }
        animatorController.currentSkillScriptableObject = playerController.playerScriptableObject.listSkillScript[i];
    }
    public void WhatISYourState()
    { 
        animatorController.currentStateSkill=animatorController.currentSkillScriptableObject.StatusOfSkill(currentAnimationFrame);        
    }
    public void LaMagie()
    {
        if (currentAnimationName != "T_Idle")
        {
            if (currentAnimationFrame == 0)
            {
                //Debug.Log(name);
                playerController.dejaEnable = false;
            }
            character.transform.parent = transform;
        }
        else
        {
            character.transform.parent = player.transform;
            /////--? ché pas ou mettre la ligne ci dessous
            character.transform.position = new Vector3(character.transform.position.x, 0.8f, character.transform.position.z);
            /////----?
        }
    }
    public void PlayAnimation(string name)
    {
        animator.SetTrigger(name);
    }
}
