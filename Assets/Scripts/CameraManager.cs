using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 positionPlayer1;
    public Vector3 positionPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((positionPlayer1.x + positionPlayer2.x) / 2, transform.position.y, transform.position.z);
    }
}
