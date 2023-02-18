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
    public GameObject scoreP1;
    public ScoreText scoreP1Manager;
    public GameObject scoreP2;
    public ScoreText scoreP2Manager;

    private void Awake()
    {
        PlayerManager = PlayerManagerGameObject.GetComponent<PlayerManager>();
    }
    private void Start()
    {
        chronos = 0;
        scoreP1Manager=scoreP1.GetComponent<ScoreText>();
        scoreP2Manager=scoreP2.GetComponent<ScoreText>();
    }
    public void Attack(GameObject player)
    {
        if(player==player1)
        {
            player2.GetComponent<LifeManager>().Hurt(100);
            if(player2.GetComponent<LifeManager>().dead)
            {
                scoreP1Manager.score++;
                player2.GetComponent<LifeManager>().Recovery(100); ;
            }
            //Debug.Log("Player 2 Hurt");
        }
        else
        {
            player1.GetComponent<LifeManager>().Hurt(100);
            if (player1.GetComponent<LifeManager>().dead)
            {
                scoreP2Manager.score++;
                player1.GetComponent<LifeManager>().Recovery(100); ;
            }
            //Debug.Log("Player 1 Hurt");
        }
        CameraObject.GetComponent<CameraManager>().shakeNow = true;
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
