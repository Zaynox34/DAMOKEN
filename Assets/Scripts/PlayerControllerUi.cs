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
        playerManagerUI.GetComponent<PlayerManagerUI>().ImReadyPlayerOne(this.gameObject);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    public void OnConfirm(InputAction.CallbackContext context)
    {
        confirmed = context.action.triggered;
        Debug.Log("DamoComfirm");
    }
    public void OnCancel(InputAction.CallbackContext context)
    {
        canceled = context.action.triggered;
        Debug.Log("DamoCANcel");
    }
    // Update is called once per frame
    void Update()
    {
        transform.position +=new Vector3(movementInput.x, movementInput.y,0) * playerSpeed * Time.deltaTime;
    }
}
