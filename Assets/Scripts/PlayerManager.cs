using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance = null;

    public PlayerInputManager playerInputManager;
    public DuelManager duelManager;
    public Transform player1Transform;
    public Transform player2Transform;

    public InputAction joinAction;
    public InputAction leaveAction;

    public event System.Action<PlayerInput> PlayerJoinedGame;
    public event System.Action<PlayerInput> PlayerLeftGame;

    //public GameObject player1;
    //public GameObject player2;

    //public PlayerScriptableObject player1ScriptableObject;
    //public PlayerScriptableObject player2ScriptableObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        playerInputManager = GetComponent<PlayerInputManager>();
        joinAction.Enable();
        joinAction.performed += context => JoinAction(context);
        leaveAction.Enable();
        leaveAction.performed += context => LeaveAction(context);
    }
    public void JoinAction(InputAction.CallbackContext context)
    {
        PlayerInputManager.instance.JoinPlayerFromActionIfNotAlreadyJoined(context);
    }
    public void LeaveAction(InputAction.CallbackContext context)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            foreach (var device in transform.GetChild(i).GetComponent<PlayerInput>().devices)
            {
                if (device != null && context.control.device == device)
                {
                    UnregisterPlayer(transform.GetChild(i).gameObject);
                    return;
                }
            }
        }
    }
    void UnregisterPlayer(GameObject playerASuprim)
    {
        if (PlayerLeftGame != null)
        {
            PlayerLeftGame(playerASuprim.GetComponent<PlayerInput>());
        }
        playerASuprim.GetComponent<PlayerControllerUi>().Akai();
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player " + (playerInputManager.playerCount - 1) + " a rejoint.");
        if (PlayerJoinedGame != null)
        {
            PlayerJoinedGame(playerInput);
        }

    }
    public void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("Player " + playerInputManager.playerCount + " a quitté.");
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    /*
    T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        var dst = destination.GetComponent(type) as T;
        if (!dst) dst = destination.AddComponent(type) as T;
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.IsStatic) continue;
            field.SetValue(dst, field.GetValue(original));
        }
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
            prop.SetValue(dst, prop.GetValue(original, null), null);
        }
        return dst as T;
    }
    */
}
