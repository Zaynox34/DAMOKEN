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
    // Start is called before the first frame update
    void Start()
    {
        
        playerManagerUI = GameObject.Find("PlayerManager");
        transform.parent = playerManagerUI.transform;
        
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementInput = context.ReadValue<Vector2>();
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
    /*
    public void Akai()
    {
        Destroy(this.gameObject);
    }
    */
    void Update()
    {
        transform.position +=new Vector3(movementInput.x, movementInput.y,0) * playerSpeed * Time.deltaTime;
    }
}
