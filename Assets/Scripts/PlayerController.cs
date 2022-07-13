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
    private InputAction slash1Action;
    private InputAction slash2Action;
    [SerializeField]
    private string skillUse;
    [SerializeField]
    private int counterFrame;
    public GameObject template;
    private Animator animator;

    [SerializeField]
    private Vector3 startSkillPosition;

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
        skillUse = "None";
        counterFrame = -1;
        playerScriptableObject.slash0.UncompressProportionPerFrame();
        playerScriptableObject.slash1.UncompressProportionPerFrame();
        playerScriptableObject.slash2.UncompressProportionPerFrame();
    }
    public void Slash0(InputAction.CallbackContext context)
    {
        if (skillUse == "None")
        {
            Debug.Log("slash 0");
            animator.SetTrigger("Slash0");
            skillUse = "Slash0";
            startSkillPosition = transform.position;
        }
    }
    public void Slash1(InputAction.CallbackContext context)
    {
        if (skillUse == "None")
        {
            Debug.Log("slash 1");
            animator.SetTrigger("Slash1");
            skillUse = "Slash1";
            startSkillPosition = transform.position;
        }
    }
    public void Slash2(InputAction.CallbackContext context)
    {
        if (skillUse == "None")
        {
            Debug.Log("slash 2");
            animator.SetTrigger("Slash2");
            skillUse = "Slash2";
            startSkillPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
        if(moveInput!=Vector2.zero)
        {
            Walk(moveInput);
        }
        CounterFrame();
    }
    public void CounterFrame()
    {
        if (skillUse == "Slash0")
        {
            
            if (playerScriptableObject.slash0.TotalSkillTime()-1 <= counterFrame)
            {
                skillUse = "None";
                startSkillPosition = Vector3.zero;
                counterFrame = -1;
            }
            else
            {
                counterFrame++;
                
                startSkillPosition.x += playerScriptableObject.slash0.proportionPerFrame[counterFrame] * playerScriptableObject.slash0.skillRange;
                transform.position = startSkillPosition;
                playerState = playerScriptableObject.slash0.StatusOfSkill(counterFrame);
            }
                
        }
        
        if (skillUse == "Slash1")
        {    
            if (playerScriptableObject.slash1.TotalSkillTime() - 1 <= counterFrame)
            {
                skillUse = "None";
                startSkillPosition = Vector3.zero;
                counterFrame = -1;
            }
            else
            {
                counterFrame++;
                startSkillPosition.x += playerScriptableObject.slash1.proportionPerFrame[counterFrame] * playerScriptableObject.slash1.skillRange;
                transform.position = startSkillPosition;
                playerState = playerScriptableObject.slash1.StatusOfSkill(counterFrame);
            }
        }
        if (skillUse == "Slash2")
        {
            Debug.Log(counterFrame + "      " + (playerScriptableObject.slash2.TotalSkillTime() - 1) + "      " + (playerScriptableObject.slash2.TotalSkillTime() - 1 < counterFrame));
            if (playerScriptableObject.slash2.TotalSkillTime() - 1 <= counterFrame)
            {
                skillUse = "None";
                startSkillPosition = Vector3.zero;
                counterFrame = -1;
            }
            else
            {
                counterFrame++;
                Debug.Log(counterFrame + "   " + playerScriptableObject.slash2.StatusOfSkill(counterFrame) + " zzzzz  " + playerScriptableObject.slash2.TotalSkillTime());
                startSkillPosition.x += playerScriptableObject.slash2.proportionPerFrame[counterFrame] * playerScriptableObject.slash2.skillRange;
                transform.position = startSkillPosition;
                playerState = playerScriptableObject.slash2.StatusOfSkill(counterFrame);
            }
        }

    }
    public void Walk(Vector2 moveInput)
    {
        transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
    }
}
