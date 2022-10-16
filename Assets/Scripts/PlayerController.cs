using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private State playerState;
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    
    private HitboxController hitboxController;
    private AnimatorController animationController;

    private InputAction slash0Action;
    private InputAction slash1Action;
    private InputAction slash2Action;
    private void Awake()
    {
        hitboxController = GetComponent<HitboxController>();
        playerScriptableObject.playerControls = new PlayerControls();
        animationController = GetComponent<AnimatorController>();
    }
    private void OnEnable()
    {
        playerScriptableObject.playerControls.Enable();
        playerScriptableObject.playerControls.War.Slash0.performed += Slash0;
        playerScriptableObject.playerControls.War.Slash1.performed += Slash1;
        playerScriptableObject.playerControls.War.Slash2.performed += Slash2;
    }
    private void OnDisable()
    {
        playerScriptableObject.playerControls.Disable();
        playerScriptableObject.playerControls.War.Slash0.performed -= Slash0;
        playerScriptableObject.playerControls.War.Slash1.performed -= Slash1;
        playerScriptableObject.playerControls.War.Slash2.performed -= Slash2;
    }
    // Start is called before the first frame update
    void Start()
    {
        hitboxController.StartCheckingCollision();   
    }
    public void Slash0(InputAction.CallbackContext context)
    {

        if (animationController.GetCurrentAnimationName() == "Idle")
        {
            animationController.PlayAnimations("Slash0");
        }
    }
    public void Slash1(InputAction.CallbackContext context)
    {
        if (animationController.GetCurrentAnimationName() == "Idle")
        {
            animationController.PlayAnimations("Slash1");
        }
    }
    public void Slash2(InputAction.CallbackContext context)
    {
        if (animationController.GetCurrentAnimationName() == "Idle")
        {
            animationController.PlayAnimations("Slash2");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            if (animationController.GetCurrentAnimationName() == "Idle")
            {
                Walk(moveInput);
            }
        }
    }
    public void Walk(Vector2 moveInput)
    {
        //Debug.Log(new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime);
        transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
    }
}
