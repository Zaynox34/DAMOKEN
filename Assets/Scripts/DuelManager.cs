using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour
{
    public float chronos;
    [SerializeField]
    private GameObject PlayerManagerGameObject;
    public float startTime;
    private PlayerManager PlayerManager;
    public string phase;
    public Transform Player1TransformStart;
    public Transform Player2TransformStart;
    public GameObject CameraObject;
    private void Awake()
    {
        PlayerManager = PlayerManagerGameObject.GetComponent<PlayerManager>();
    }
    private void Start()
    {
        chronos = 0;
    }
    public void ChronosManager()
    {
        if (chronos == 0)
        {
            phase = "Void";
        }
        else
        {
            if (chronos < startTime)
            {
                phase = "Ready";
            }
            else
            {
                if (chronos >= startTime)
                {
                    phase = "Go";
                }
            }
        }
        
        if (PlayerManager.playerInputManager.playerCount >= 2)
        {
            chronos += Time.deltaTime;
        }
    }
    private void Update()
    {
        ChronosManager();
    }
}
