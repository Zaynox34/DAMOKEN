using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject character;
    public GameObject player;
    private Animator animator;
    public AnimatorStateInfo currentAnimatorStateInfo;
    public AnimationClip currentAnimationClip;
    public string currentAnimationName;
    public int currentAnimationFrame;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
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
            character.transform.parent = transform;
            //character.transform.position = new Vector3(transform.position.x, 0.8f, transform.position.z);
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
