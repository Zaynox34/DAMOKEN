using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private PlayerControls playerControls;
    public float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        float move = playerControls.War.Move.ReadValue<float>();
        transform.position += new Vector3(move * speed, 0, 0) * Time.deltaTime;
    }
}
