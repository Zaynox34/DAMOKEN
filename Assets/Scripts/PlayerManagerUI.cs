using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManagerUI : MonoBehaviour
{
    public GameObject background;
    private SpriteRenderer spriteRenderer;
    public Sprite screenStartImage;
    public Sprite screenSelectController;
    public float playerSpeed;

    public static PlayerManagerUI instance = null;

    public PlayerInputManager playerInputManager;
    public Transform player1Transform;
    public Transform player2Transform;
    public Transform controllerTransform;

    public InputAction joinAction;
    public InputAction leaveAction;
    //event
    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=null)
        {
            Destroy(gameObject);
        }
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        playerInputManager = GetComponent<PlayerInputManager>();
        spriteRenderer.sprite = screenStartImage;
        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);
        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
    }
    void Start()
    {
        /*PlayerInputManager.instance.JoinPlayer(0, -1, null);*/
    }
    public void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }
    public void LeaveAction(InputAction.CallbackContext context)
    {

    }
    public void Cancel ()
    {
        for (int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).GetComponent<PlayerControllerUi>().Akai();
        }
        SceneManager.LoadScene(0);
        spriteRenderer.sprite = screenStartImage;

    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + (playerInputManager.playerCount -1) + " a rejoint.");
        if (playerInputManager.playerCount > 0  && screenStartImage==spriteRenderer.sprite)
        {
            spriteRenderer.sprite = screenSelectController;    
        }
        if(PlayerJoinedGame !=null)
        {
            PlayerJoinedGame(playerInput);
        }
        
    }
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInputManager.playerCount + " a quitt�.");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
