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
        for (int i = 0; i < transform.childCount; i++)
        {
           if (transform.GetChild(i).gameObject.activeSelf)
            {
                
                collidersCount += Physics.OverlapBox(transform.GetChild(i).transform.position,
                transform.GetChild(i).transform.localScale / 2,
                transform.GetChild(i).transform.rotation, mask).Length;
                Debug.Log(Physics.OverlapBox(transform.GetChild(i).transform.position,
                transform.GetChild(i).transform.localScale / 2,
                transform.GetChild(i).transform.rotation, mask).Length);
            }
        }
        _state = collidersCount > 0 ? ColliderState.Colliding : ColliderState.Open;
        if(_state==ColliderState.Colliding)
        {
            Debug.Log("Chicken float");
        }
        collidersCount = 0;
    }
    public void HitboxUpdate()
    {
        CheckCollision();
        CheckGizmoColor();

        for(int i=0; i<transform.childCount; i++)
        {
            //Debug.Log(i);
            transform.GetChild(i).GetComponent<MeshRenderer>().material = hitboxMatDisplay;
        }
    }
    public void Start()
    {
    }
    private void Update()
    {
        if (_state != ColliderState.Closed)
        {
            HitboxUpdate();
        }
    }
}
