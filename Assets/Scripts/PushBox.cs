using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    public bool onColidder;
    // Start is called before the first frame update
    void Start()
    {
        onColidder = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        onColidder = true;
    }
    private void OnTriggerExit(Collider other)
    {
        onColidder = false;
    }
    
}
