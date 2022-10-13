using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField]
    private State playerState;
    [SerializeField]
    private PlayerScriptableObject playerScriptableObject;
    private InputAction slash0Action;
    private InputAction slash1Action;
    private InputAction slash2Action;
    [SerializeField]
    public string skillUse;
    [SerializeField ]
    private SkillScriptableObject skillScriptUse;
    [SerializeField]
    private int counterFrame;
    //public GameObject template;
    //private Animator animator;

    [SerializeField]
    private Vector3 startSkillPosition;

    [SerializeField]
    private HitboxController hitboxController;
    //public Collider[] colliders;
    //public Vector3 boxSize;
    //public LayerMask colisionLayerMask;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        playerScriptableObject.playerControls = new PlayerControls();
        //animator = template.GetComponent<Animator>();
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
            //animator.SetTrigger("Slash0");
            skillUse = "Slash0";
            startSkillPosition = transform.position;
        }
    }
    public void Slash1(InputAction.CallbackContext context)
    {
        if (skillUse == "None")
        {
            Debug.Log("slash 1");
            //animator.SetTrigger("Slash1");
            skillUse = "Slash1";
            startSkillPosition = transform.position;
        }
    }
    public void Slash2(InputAction.CallbackContext context)
    {
        if (skillUse == "None")
        {
            Debug.Log("slash 2");
            //animator.SetTrigger("Slash2");
            skillUse = "Slash2";
            startSkillPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = playerScriptableObject.playerControls.War.Walk.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            Walk(moveInput);
        }
        SwitchSkill();
        CounterFrame();
    }
    private void SwitchSkill()
    {
        switch (skillUse)
        {
            case "None":
                {
                    skillScriptUse = null;
                    hitboxController.attackScriptUse = null;
                    break;
                }
            case "Slash0":
                {
                    skillScriptUse = playerScriptableObject.slash0;
                    hitboxController.attackScriptUse=playerScriptableObject.slash0;
                    hitboxController.StartCheckingCollision();
                    break;
                }
            case "Slash1":
                {
                    skillScriptUse = playerScriptableObject.slash1;
                    hitboxController.attackScriptUse = playerScriptableObject.slash1;
                    hitboxController.StartCheckingCollision();
                    break;
                }
            case "Slash2":
                {
                    skillScriptUse = playerScriptableObject.slash2;
                    hitboxController.attackScriptUse = playerScriptableObject.slash2;
                    hitboxController.StartCheckingCollision();
                    break;
                }
            default:
                break;
        }
    }
    public void CounterFrame()
    {
        if (skillUse != "None")
        {
            if (skillScriptUse.TotalSkillTime() - 1 <= counterFrame)
            {
                hitboxController.StopCheckingCollision();
                skillUse = "None";
                startSkillPosition = Vector3.zero;
                counterFrame = -1;
            }

            else
            {
                counterFrame++;

                startSkillPosition.x += skillScriptUse.proportionPerFrame[counterFrame] * skillScriptUse.skillRange;
                transform.position = startSkillPosition;
                playerState = skillScriptUse.StatusOfSkill(counterFrame);
            }
        }
    }
    public void Walk(Vector2 moveInput)
    {
        transform.position += new Vector3(moveInput.x * playerScriptableObject.speed, 0, 0) * Time.deltaTime;
    }
}

