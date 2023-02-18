using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Vector3 positionPlayer1;
    public Vector3 positionPlayer2;
    public AnimatorController animatorControllerPlayer1;
    public AnimatorController animatorControllerPlayer2;
    public Transform sauronP1Transform;
    public Transform sauronP2Transform;

    public float shakeTime;
    public float chronos;
    public bool shakeNow;
    public float shakeAmplitude;
    public Vector3 randomiser;
    public Vector3 truePosition;
    public float speedLerp;

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
        transform.position = truePosition;
        if(animatorControllerPlayer1!=null && animatorControllerPlayer2!=null)
        {
            positionPlayer1 = animatorControllerPlayer1.character.transform.position;
            positionPlayer2 = animatorControllerPlayer2.character.transform.position;
            if(animatorControllerPlayer1.GetCurrentAnimationName() == "Idle")
            {
                sauronP1Transform.position = positionPlayer1;
            }
            if (animatorControllerPlayer2.GetCurrentAnimationName() == "Idle")
            {
                sauronP2Transform.position = positionPlayer2;
            }
        }
        truePosition = new Vector3(Mathf.Lerp(truePosition.x,(sauronP1Transform.position.x+sauronP2Transform.position.x)/2, Time.deltaTime*speedLerp), truePosition.y, truePosition.z);
        transform.position = truePosition;
        if (chronos>=shakeTime)
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
