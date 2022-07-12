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
    private InputAction slash0Action;
    [SerializeField]
    private string skillUse;
    [SerializeField]
    private int counterFrame;
    public GameObject template;
    private Animator animator;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        playerScriptableObject.playerControls = new PlayerControls();
        animator = template.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        playerScriptableObject.playerControls.Enable();
        playerScriptableObject.playerControls.War.Slash0.performed += Slash0;
    }
    private void OnDisable()
    {
        playerScriptableObject.playerControls.Disable();
        playerScriptableObject.playerControls.War.Slash0.performed -= Slash0;
    }
    // Start is called before the first frame update
    void Start()
    {
        skillUse = "None";
        counterFrame = 0;
    }
    public void Slash0(InputAction.CallbackContext context)
    {
        Debug.Log("slash");
        animator.SetTrigger("Slash0");
        skillUse = "Slash0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
        if(moveInput!=Vector2.zero)
        {
            Walk(moveInput);
        }
        /*if (playerScriptableObject.playerControls.War.Slash0.triggered)
        {
            Debug.Log("SlAAAAAAAAAAAAAAAAAAAAASSSSSSSSSSSSSSSSSSSHHHHHHHH");
        }
        */
        CounterFrame();
    }
    public void CounterFrame()
    {
        if(skillUse=="Slash0")
        {
            if (playerScriptableObject.slash0.TotalSkillTime() < counterFrame)
            {
                skillUse = "None";
                counterFrame = 0;
            }
            else
            {
                Debug.Log(counterFrame);
                counterFrame++;
                playerState = playerScriptableObject.slash0.StatusOfSkill(counterFrame);
            }

        }
    }
    public void Walk(Vector2 moveInput)
    {
        transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
    }
}
