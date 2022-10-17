using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject character;
    public GameObject player;
    private PlayerController playerController;
    private Animator animator;
    public AnimatorStateInfo currentAnimatorStateInfo;
    public AnimationClip currentAnimationClip;
    public string currentAnimationName;
    public int currentAnimationFrame;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();
    }
    public void GetInfoAnimation()
    {

        currentAnimationClip = animator.GetCurrentAnimatorClipInfo(default)[0].clip;
        currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        currentAnimationName = currentAnimationClip.name;
        currentAnimationFrame = (int)
            (currentAnimatorStateInfo.normalizedTime *
            (currentAnimationClip.length *
            currentAnimationClip.frameRate));
        if(currentAnimationName!="T_Idle")
        {
            if(currentAnimationFrame==0)
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
