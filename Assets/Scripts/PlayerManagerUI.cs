using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManagerUI : MonoBehaviour
{
    public GameObject background;
    private SpriteRenderer spriteRenderer;
    public Sprite screenStartImage;
    public Sprite screenSelectController;
    public float playerSpeed;
    public PlayerInputManager playerInputManager;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = background.GetComponent<SpriteRenderer>();
        playerInputManager = GetComponent<PlayerInputManager>();
        spriteRenderer.sprite = screenStartImage;
    }
    public void Cancel ()
    {
        /*
        for(int i=0;i<transform.childCount;i++)
        {
            transform.GetChild(i).GetComponent<PlayerControllerUi>().Akai();
        }
        */
        SceneManager.LoadScene(0);
        spriteRenderer.sprite = screenStartImage;
    }
    public void OnPlayerJoined()
    {
        Debug.Log("Player " + (playerInputManager.playerCount -1) + " a rejoint.");
        if (playerInputManager.playerCount > 0  && screenStartImage==spriteRenderer.sprite)
        {
            spriteRenderer.sprite = screenSelectController;    
        }
    }
    public void OnPlayerLeft()
    {
        Debug.Log("Player " + playerInputManager.playerCount + " a quitté.");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
