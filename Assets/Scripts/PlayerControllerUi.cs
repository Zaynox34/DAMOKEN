using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerUi : MonoBehaviour
{
    public float playerSpeed;
    //public bool confirmed;
    //public bool canceled;
    public Vector2 movementInput=Vector2.zero;
    public int playerIndex;
    public GameObject playerManagerUI;
    private PlayerManagerUI playerManagerUIConponent;
    public Vector3 target;
    public bool verouiler;
    


    // Start is called before the first frame update
    void Start()
    {
        playerManagerUI = GameObject.Find("PlayerManager");
        transform.parent = playerManagerUI.transform;
        playerManagerUIConponent = playerManagerUI.GetComponent<PlayerManagerUI>();
        transform.position=playerManagerUIConponent.controllerTransform.position;
        target = playerManagerUIConponent.controllerTransform.position;
        verouiler = false;
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!verouiler)
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
                if (playerManagerUIConponent.player1 != null && target == playerManagerUIConponent.player1Transform.position)
                {
                    target = playerManagerUIConponent.controllerTransform.position;
                }
                if (playerManagerUIConponent.player2 != null && target == playerManagerUIConponent.player2Transform.position)
                {
                    target = playerManagerUIConponent.controllerTransform.position;
                }
            }
        }
        
        
    }
    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //confirmed = context.action.triggered;
            //Debug.Log("DamoComfirm");
            if (playerManagerUIConponent.player1 == this.gameObject)
            {
                Debug.Log("DAMOREADY 1");
                playerManagerUIConponent.readyplayer1=true;
                verouiler = true;
            }
            if (playerManagerUIConponent.player2 == this.gameObject)
            {
                Debug.Log("DAMOREADY 2");
                playerManagerUIConponent.readyplayer2 = true;
                
                verouiler = true;
            }
        } 
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //canceled = context.action.triggered;
            if(!verouiler)
            {
                playerManagerUI.GetComponent<PlayerManagerUI>().Cancel();
            }
            Debug.Log("DamoCANcel");
            if (playerManagerUIConponent.player1 == this.gameObject)
            {
                Debug.Log("DAMOKANCEL 1");
                playerManagerUIConponent.readyplayer1 = false;
                verouiler = false;
            }
            if (playerManagerUIConponent.player2 == this.gameObject)
            {
                Debug.Log("DAMOKANCEL 2");
                playerManagerUIConponent.readyplayer2 = false;
                verouiler = false;
            }
        }
    }
    // Update is called once per frame
    public void Akai()
    { 
        Destroy(this.gameObject);  
    }
    
    public void MotherFucker()
    {
        transform.parent = null;
    }
    void Update()
    { 
        if(target.x-transform.position.x<=0.2f&& target.x - transform.position.x >= -0.2f)
        {
            transform.position = target;
        }
        else
        { 
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * playerSpeed);
        }
        
    }
}
