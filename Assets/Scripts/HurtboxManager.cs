using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtboxManager : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        if (playerController.playerId == 1)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).tag = "Player1";
            }
        }
        if (playerController.playerId == 2)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).tag = "Player2";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
