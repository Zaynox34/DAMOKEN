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
    public GameObject player1;
    public GameObject player2;
    public PlayerController player1Controller;
    public PlayerController player2Controller;
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
    public GameObject QuiEstMonEnemy(GameObject g)
    {
        if(g.GetComponent<PlayerController>().playerId==1)
        {
            return player2;
        }
        else
        {
            return player1;
        }
    }
    private void Update()
    {
        ChronosManager();
    }
}
