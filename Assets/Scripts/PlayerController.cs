using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private State playerState;
    public PlayerScriptableObject playerScriptableObject;
    
    private HitboxController hitboxController;
    private AnimatorController animatorController;
    public Vector2 moveInput;
    public bool dejaEnable; //bolean qui evite le double input et oblige un decalage
    private void Awake()
    {
        hitboxController = GetComponent<HitboxController>();
        playerScriptableObject.playerControls = new PlayerControls();
        animatorController = GetComponent<AnimatorController>();
        /*
        Debug.Log(GetComponent<PlayerInput>().actions);
        Debug.Log(GetComponent<PlayerInput>().currentControlScheme);
        
        InputDevice a = Gamepad.current;
        GetComponent<PlayerInput>().SwitchCurrentControlScheme(Gamepad.current);
        Debug.Log(GetComponent<PlayerInput>().actions);
        Debug.Log(GetComponent<PlayerInput>().currentControlScheme);*/
    }
    private void OnEnable()
    {
        playerScriptableObject.playerControls.Enable();
        playerScriptableObject.playerControls.War.Slash0.performed += Slash0;
        playerScriptableObject.playerControls.War.Slash1.performed += Slash1;
        playerScriptableObject.playerControls.War.Slash2.performed += Slash2;

        playerScriptableObject.playerControls.War.Dash.performed += Dash;
    }
    private void OnDisable()
    {
        
        playerScriptableObject.playerControls.Disable();
        playerScriptableObject.playerControls.War.Slash0.performed -= Slash0;
        playerScriptableObject.playerControls.War.Slash1.performed -= Slash1;
        playerScriptableObject.playerControls.War.Slash2.performed -= Slash2;

        playerScriptableObject.playerControls.War.Dash.performed -= Dash;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        hitboxController.StartCheckingCollision();
        dejaEnable =false;
        moveInput = Vector2.zero;
    }
    public void Slash0(InputAction.CallbackContext context)
    {

        if ((animatorController.GetCurrentAnimationName() == "Idle")&& !dejaEnable)
        {
            dejaEnable = true;
            animatorController.PlayAnimations("Slash0");
        }
        else
        { 
            if(animatorController.PeutCanceler(playerScriptableObject.listSkillScript[1]) && !dejaEnable)
            {
                dejaEnable = true;
                animatorController.PlayAnimations("Cancel");
                animatorController.PlayAnimations("Slash0");
            }
        }
    }
    public void Slash1(InputAction.CallbackContext context)
    {
        if ((animatorController.GetCurrentAnimationName() == "Idle") && !dejaEnable)
        {
            dejaEnable = true;
            animatorController.PlayAnimations("Slash1");
        }
        else
        {
            if (animatorController.PeutCanceler(playerScriptableObject.listSkillScript[2]) && !dejaEnable)
            {
                dejaEnable = true;
                animatorController.PlayAnimations("Cancel");
                animatorController.PlayAnimations("Slash1");
            }
        }
    }
    public void Slash2(InputAction.CallbackContext context)
    {
        if ((animatorController.GetCurrentAnimationName() == "Idle") && !dejaEnable)
        {
            dejaEnable = true;
            animatorController.PlayAnimations("Slash2");
        }
        else
        {
            if (animatorController.PeutCanceler(playerScriptableObject.listSkillScript[3]) && !dejaEnable)
            {
                dejaEnable = true;
                animatorController.PlayAnimations("Cancel");
                animatorController.PlayAnimations("Slash2");
            }
        }
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (moveInput.x < 0)
        {
            if ((animatorController.GetCurrentAnimationName() == "Idle") && !dejaEnable)
            {
                dejaEnable = true;
                animatorController.PlayAnimations("BackDash");
            }
            else
            {
                if (animatorController.PeutCanceler(playerScriptableObject.listSkillScript[5]) && !dejaEnable)
                {
                    dejaEnable = true;
                    animatorController.PlayAnimations("Cancel");
                    animatorController.PlayAnimations("BackDash");
                }
            }
        }
        else
        {
            if ((animatorController.GetCurrentAnimationName() == "Idle") && !dejaEnable)
            {
                dejaEnable = true;
                animatorController.PlayAnimations("FrontDash");
            }
            else
            {
                if (animatorController.PeutCanceler(playerScriptableObject.listSkillScript[4]) && !dejaEnable)
                {
                    dejaEnable = true;
                    animatorController.PlayAnimations("Cancel");
                    animatorController.PlayAnimations("FrontDash");
                }
            }
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            if (animatorController.GetCurrentAnimationName() == "Idle")
            {
                Walk(moveInput);
            }
        }
    }
    public void Walk(Vector2 moveInput)
    {
        transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
    }
}
