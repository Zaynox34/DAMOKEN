using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerUi : MonoBehaviour
{
    public float playerSpeed;
    public bool confirmed;
    public bool canceled;
    public Vector2 movementInput=Vector2.zero;
    public int playerIndex;
    public GameObject playerManagerUI;
    private PlayerManagerUI playerManagerUIConponent;
    public Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        playerManagerUI = GameObject.Find("PlayerManager");
        transform.parent = playerManagerUI.transform;
        playerManagerUIConponent = playerManagerUI.GetComponent<PlayerManagerUI>();
        transform.position=playerManagerUIConponent.controllerTransform.position;
        target = playerManagerUIConponent.controllerTransform.position;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
            if (target == playerManagerUIConponent.controllerTransform.position)
            {
                if (movementInput.x < 0)
                {
                    target = playerManagerUIConponent.player1Transform.position;
                }
                if (movementInput.x > 0)
                {
                    target = playerManagerUIConponent.player2Transform.position;
                }
            }
            else
            {
                if (target == playerManagerUIConponent.player1Transform.position)
                {
                    if (movementInput.x < 0)
                    {
                        target = playerManagerUIConponent.player1Transform.position;
                    }
                    if (movementInput.x > 0)
                    {
                        target = playerManagerUIConponent.controllerTransform.position;
                    }
                }
                else
                {
                    if (target == playerManagerUIConponent.player2Transform.position)
                    {
                        if (movementInput.x < 0)
                        {
                            target = playerManagerUIConponent.controllerTransform.position;
                        }
                        if (movementInput.x > 0)
                        {
                            target = playerManagerUIConponent.player2Transform.position;
                        }
                    }
                }
            }
        }
        
        
    }
    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            confirmed = context.action.triggered;
            Debug.Log("DamoComfirm");
        } 
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            canceled = context.action.triggered;
            playerManagerUI.GetComponent<PlayerManagerUI>().Cancel();
            Debug.Log("DamoCANcel");
        }
    }
    // Update is called once per frame
    public void Akai()
    {
        
        Destroy(this.gameObject);
        
    }
    
    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * playerSpeed);
        
    }
}
