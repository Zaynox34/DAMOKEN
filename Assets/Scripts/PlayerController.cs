using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private State playerState;
    public DuelManager duelManager;
    public GameObject playerManagerGameObject;
    public PlayerManager playerManager;
    public GameObject CameraGameObject;
    public CameraManager CameraManager;
    public PlayerScriptableObject playerScriptableObject;
    private PlayerInput playerinput;
    private InputAction walkAction;
    private HitboxController hitboxController;
    private AnimatorController animatorController;

    public int playerId;
    public Vector2 moveInput;
    public bool dejaEnable; //bolean qui evite le double input et oblige un decalage
    private void Awake()
    {
        
        playerManagerGameObject = GameObject.Find("PlayerManager");
        transform.parent = playerManagerGameObject.transform;
        playerManager = playerManagerGameObject.GetComponent<PlayerManager>();
        playerId = playerManager.playerInputManager.playerCount;
        duelManager = playerManager.duelManager;
        playerinput = GetComponent<PlayerInput>();
        walkAction = playerinput.actions["Walk"];
        hitboxController = GetComponent<HitboxController>();
        animatorController = GetComponent<AnimatorController>();
        CameraGameObject = duelManager.CameraObject;
        CameraManager = CameraGameObject.GetComponent<CameraManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        if (playerId==1)
        {
            transform.position = duelManager.Player1TransformStart.position;
            transform.localScale = duelManager.Player1TransformStart.localScale;
        }
        if (playerId == 2)
        {
            transform.position = duelManager.Player2TransformStart.position;
            transform.localScale = duelManager.Player2TransformStart.localScale;
        }
        hitboxController.StartCheckingCollision();
        dejaEnable =false;
        moveInput = Vector2.zero;
    }
    public void Slash0(InputAction.CallbackContext context)
    {
        if (duelManager.phase == "Go")
        {
            if (context.performed)
            {
                if ((animatorController.GetCurrentAnimationName() == "Idle") && !dejaEnable)
                {
                    dejaEnable = true;
                    animatorController.PlayAnimations("Slash0");
                }
                else
                {
                    if (animatorController.PeutCanceler(playerScriptableObject.listSkillScript[1]) && !dejaEnable)
                    {
                        dejaEnable = true;
                        animatorController.PlayAnimations("Cancel");
                        animatorController.PlayAnimations("Slash0");
                    }
                }
            }
        }
    }
    public void Slash1(InputAction.CallbackContext context)
    {
        if (duelManager.phase == "Go")
        {
            if (context.performed)
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
        }
    }
    public void Slash2(InputAction.CallbackContext context)
    {
        if (duelManager.phase == "Go")
        {
            if (context.performed)
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
        }
    }
    public void Dash(InputAction.CallbackContext context)
    {
        if (duelManager.phase == "Go")
        {
            if (context.performed)
            {
                if (moveInput.x*transform.localScale.x < 0)
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (duelManager.phase == "Go")
        {
            if (playerId == 1)
            {
                CameraManager.positionPlayer1 = transform.position;
            }
            if (playerId == 2)
            {
                CameraManager.positionPlayer2 = transform.position;
            }
        }
            moveInput = walkAction.ReadValue<Vector2>();
        //moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
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
        if (duelManager.phase == "Go")
        {
            transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
        }
    }
}
