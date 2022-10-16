using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    [Header("UseInGame")]
    public AttackScriptableObject attackScriptUse;
    [SerializeField]
    private ColliderState _state;
    public LayerMask mask;
    public int collidersCount;
    public bool peutVoir;
    
    private Material hitboxMatDisplay;
    [Header("Material")]
    public Material hitboxInnactiveMat;
    public Material hitboxActiveMat;
    public Material hitboxHitMat;
    [Header("GameObject/Prefab")]

    public GameObject hitboxPrefab;
    public GameObject hitBoxDisplay;
    [Header("List")]
    public List<Transform> colideBoxToCheck;

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
    public void ResetHitbox()
    {
        collidersCount = 0;
        for (int i = 0; i < hitBoxDisplay.transform.childCount; i++)
        {
            Destroy(hitBoxDisplay.transform.GetChild(i).gameObject);
        }
    }
    public GameObject CreateHitBox(Vector3 position,Vector3 scale,Transform parent)
    {
        GameObject gameObject = Instantiate(hitboxPrefab);
        gameObject.transform.position = position;
        gameObject.transform.localScale = scale;
        gameObject.transform.parent = parent;
        return gameObject;
    }
    public void DisplayHitbox(Transform hitBoxTransform)
    {
        GameObject tmp = CreateHitBox(hitBoxTransform.transform.position + transform.position,
                hitBoxTransform.transform.localScale, hitBoxDisplay.transform);
        if (collidersCount > 0)
        {
            tmp.GetComponent<MeshRenderer>().material = hitboxMatDisplay;

        }
    }
    public void HitboxUpdate()
    {
        ResetHitbox();
        CheckGizmoColor();
        for (int i = 0; /*(colliders.Length <= 0) &&*/ (i < colideBoxToCheck.Count); i++)
        {
            collidersCount+=Physics.OverlapBox(colideBoxToCheck[i].transform.position+transform.position,
                colideBoxToCheck[i].transform.localScale/2,
                colideBoxToCheck[i].transform.rotation, mask).Length;
            if(peutVoir)
            {
                DisplayHitbox(colideBoxToCheck[i]);
            }
        }
        _state = collidersCount > 0 ? ColliderState.Colliding : ColliderState.Open;   
    }
    public void Start()
    {
        colideBoxToCheck = new List<Transform>();
        GameObject test = new GameObject();
        test.transform.position = Vector3.zero;
        test.transform.localScale = Vector3.one;  
        colideBoxToCheck.Add(test.transform);
        
        GameObject test2 = new GameObject();
        test2.transform.position = new Vector3(0,2,0);
        test2.transform.localScale = Vector3.one;
        colideBoxToCheck.Add(test2.transform);
        

    }
    private void Update()
    {
        if (_state != ColliderState.Closed)
        {
            HitboxUpdate();
        }
    }
}
