using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    [Header("UseInGame")]
    //public AttackScriptableObject attackScriptUse;
    [SerializeField]
    private ColliderState _state;
    public LayerMask mask;
    private Material hitboxMatDisplay;
    [Header("Material")]
    public Material hitboxInnactiveMat;
    public Material hitboxActiveMat;
    public Material hitboxHitMat;
    public GameObject player;
    public PlayerController playerController;
    /*[Header("GameObject/Prefab")]

    public GameObject hitboxPrefab;
    public GameObject hitBoxDisplay;
    [Header("List")]
    public List<Transform> colideBoxToCheck;
    */
    private void CheckGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                hitboxMatDisplay = hitboxInnactiveMat;
                break;
            case ColliderState.Open:
                hitboxMatDisplay = hitboxActiveMat;
                break;
            case ColliderState.Colliding:
                hitboxMatDisplay = hitboxHitMat;
                break;
        }
    }
    public void StartCheckingCollision()
    {
        _state = ColliderState.Open;
    }

    public void StopCheckingCollision()
    {
        _state = ColliderState.Closed;
    }
    public void CheckCollision()
    {
        int collidersCount = 0;
        for (int i = 0; i < transform.childCount; i++)// sa parcours les enfant
        {
           if (transform.GetChild(i).gameObject.activeSelf)// si la hitbox est activer
            {
                /*
                collidersCount += Physics.OverlapBox(transform.GetChild(i).transform.position,
                transform.GetChild(i).transform.localScale / 2,
                transform.GetChild(i).transform.rotation, mask).Length;
                */
                Collider[] elleMarchePasEtIlEst1HduMat = Physics.OverlapBox(transform.GetChild(i).transform.position,
                transform.GetChild(i).transform.localScale / 2,
                transform.GetChild(i).transform.rotation, mask);
                List<Collider> ACollider=new List<Collider>();
                for (int x =0;x< elleMarchePasEtIlEst1HduMat.Length;x+=1)
                {
                    if(elleMarchePasEtIlEst1HduMat[x].tag!=tag)
                    {
                        ACollider.Add(elleMarchePasEtIlEst1HduMat[x]);
                    }
                }
                collidersCount += ACollider.Count;
                /*Debug.Log(Physics.OverlapBox(transform.GetChild(i).transform.position,
                transform.GetChild(i).transform.localScale / 2,
                transform.GetChild(i).transform.rotation, mask).Length);// check box 
                */
            }
        }
        _state = collidersCount > 0 ? ColliderState.Colliding : ColliderState.Open;
        if(_state==ColliderState.Colliding)
        {
            Debug.Log("Kill");
        }
        collidersCount = 0;
    }
    public void HitboxUpdate()
    {
        CheckCollision();
        CheckGizmoColor();

        for(int i=0; i<transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().material = hitboxMatDisplay;
        }
    }
    public void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        if(playerController.playerId==1)
        {
            tag = "Player1";
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).tag = "Player1";
            }
        }
        if (playerController.playerId == 2)
        {
            tag = "Player2";
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).tag = "Player2";
            }
        }
    }
    private void Update()
    {
        if (_state != ColliderState.Closed)
        {
            HitboxUpdate();
        }
    }
}
