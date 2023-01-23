using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerManagerUI : MonoBehaviour
{
    public GameObject background;
    private SpriteRenderer spriteRenderer;
    public Sprite screenStartImage;
    public Sprite screenSelectController;
    public float playerSpeed;
    public PlayerInputManager playerInputManager;
    //public List<GameObject> players;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        playerInputManager = GetComponent<PlayerInputManager>();
        spriteRenderer.sprite = screenStartImage;
    }
    public void ImReadyPlayerOne(GameObject player)
    {
        //players.Add(player);
    }
    public void OnPlayerJoined()
    {
        Debug.Log("Player " + playerInputManager.playerCount + "a rejoint.");
        if (playerInputManager.playerCount > 0  && screenStartImage==spriteRenderer.sprite)
        {
            spriteRenderer.sprite = screenSelectController;    
        }
    }
    public void OnPlayerLeft()
    {
        Debug.Log("Player " + playerInputManager.playerCount + " a quitt�.");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
