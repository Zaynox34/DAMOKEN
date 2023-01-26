using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControllerUI : MonoBehaviour
{
    public float playerSpeed;
    public Vector2 movementInput=Vector2.zero;
    public int playerIndex;
    public GameObject playerManagerUI;
    private PlayerManagerUI playerManagerUIConponent;
    private Vector3 target;
    public bool verouiler;
    


    // Start is called before the first frame update
    void Start()
    {
        playerManagerUI = GameObject.Find("PlayerManager");
        transform.parent = playerManagerUI.transform;
        playerManagerUIConponent = playerManagerUI.GetComponent<PlayerManagerUI>();
        playerIndex = playerManagerUI.transform.childCount - 1;
        transform.position=playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
        target = playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
        verouiler = false;
        
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!verouiler)
        {
            if (context.performed)
            {

                movementInput = context.ReadValue<Vector2>();
                if (target == playerManagerUIConponent.controllerTransform.position-(new Vector3(0,2,0)*playerIndex))
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
                            target = playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
                        }
                    }
                    else
                    {
                        if (target == playerManagerUIConponent.player2Transform.position)
                        {
                            if (movementInput.x < 0)
                            {
                                target = playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
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
                    target = playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
                }
                if (playerManagerUIConponent.player2 != null && target == playerManagerUIConponent.player2Transform.position)
                {
                    target = playerManagerUIConponent.controllerTransform.position - (new Vector3(0, 2, 0) * playerIndex);
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
