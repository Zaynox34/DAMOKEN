using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public AttackScriptableObject attackScriptUse;
    public LayerMask mask;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public GameObject hitboxPrefab;
    public GameObject hitBoxDisplay;
    public Material hitboxMatDisplay;
    public Material hitboxInnactiveMat;
    public Material hitboxActiveMat;
    public Material hitboxHitMat;
    //public Color collidingColor;
    public int collidersCount;
    public List<Transform> colideBoxToCheck;
    [SerializeField]
    private ColliderState _state;
    public bool peutVoir;

    private void checkGizmoColor()
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
    private void Awake()
    {
        peutVoir = false;
    }
    /*
    private void OnDrawGizmos()
    {
        if (peutVoir)
        {
            Debug.Log("aaaa");
            checkGizmoColor();
            foreach (ColidBox c in colideBoxToCheck)
            {
                Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
                Gizmos.DrawCube(c.center, new Vector3(c.boxSize.x * 2, c.boxSize.y * 2, c.boxSize.z * 2)); // Because size is halfExtents
            }
        }
    }
   */     
    public void startCheckingCollision()
    {
        peutVoir = true;
        
        _state = ColliderState.Open;
    }

    public void stopCheckingCollision()
    {
        peutVoir = false;
        _state = ColliderState.Closed;
    }
    public void hitboxUpdate()
    {
        checkGizmoColor();

        /*
        foreach (List<ColidBox>l in attackScriptUse.hitboxColider)
        {
            colideBoxToCheck = l;
        }
        */

        collidersCount = 0;
        for (int i = 0; i < hitBoxDisplay.transform.childCount; i++)
        {
            Destroy(hitBoxDisplay.transform.GetChild(i).gameObject);
        }
        for (int i = 0; /*(colliders.Length <= 0) &&*/ (i < colideBoxToCheck.Count); i++)
        {
            Debug.Log("z");
            collidersCount+=Physics.OverlapBox(colideBoxToCheck[i].transform.position+transform.position, colideBoxToCheck[i].transform.localScale/2, colideBoxToCheck[i].transform.rotation, mask).Length;
            GameObject tmp = Instantiate(hitboxPrefab);
            tmp.transform.position = colideBoxToCheck[i].transform.position + transform.position;
            tmp.transform.localScale = colideBoxToCheck[i].transform.localScale;
            tmp.transform.parent = hitBoxDisplay.transform;
            if (collidersCount > 0)
            {
                tmp.GetComponent<MeshRenderer>().material = hitboxMatDisplay;
            }

        }
        Debug.Log("a");

        if (collidersCount > 0)
        {
            _state = ColliderState.Colliding;
            Debug.Log("We hit something");
        }

        else
        {
            _state = ColliderState.Open;
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
            hitboxUpdate();
        }
    }
}
