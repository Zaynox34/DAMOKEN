using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 positionPlayer1;
    public Vector3 positionPlayer2;
    public float shakeTime;
    public float chronos;
    public bool shakeNow;
    public float shakeAmplitude;
    public Vector3 randomiser;
    public Vector3 truePosition;

    // Start is called before the first frame update
    void Start()
    {
        chronos = -1;
        shakeNow = false;
        truePosition = transform.position;
    }
    public void Shake()
    {
        randomiser=new Vector3((Random.Range(-1f, 1f)), (Random.Range(-1f, 1f)), 0)* shakeAmplitude;
        transform.position += randomiser;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        truePosition = new Vector3((positionPlayer1.x + positionPlayer2.x) / 2, truePosition.y, truePosition.z);*/
        transform.position = truePosition;
        if(chronos>=shakeTime)
        {
            chronos = -1;
        }
        if(shakeNow)
        {
            chronos = 0;
            shakeNow = false;
        }
        if(chronos>=0)
        {
            Shake();
            chronos += Time.deltaTime;
        }
    }
}
