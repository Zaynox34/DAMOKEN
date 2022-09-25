using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxController : MonoBehaviour
{
    public AttackScriptableObject attackScriptUse;
    public LayerMask mask;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidingColor;
    public Collider[] colliders;
    private List<ColidBox> colideBoxToCheck;
    [SerializeField]
    private ColliderState _state;
    public bool peutVoir;

    private void checkGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }
    private void Awake()
    {
        peutVoir = false;
    }
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
        
    public void startCheckingCollision()
    {
        peutVoir = true;
        colideBoxToCheck = attackScriptUse.hitboxColider[0];
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
        for (int i = 0; (colliders.Length <= 0) && (i < colideBoxToCheck.Count); i++)
        {            
            Physics.OverlapBox(colideBoxToCheck[i].center, colideBoxToCheck[i].boxSize, transform.rotation, mask);
        }
       
        if (colliders.Length > 0)
        {
            _state = ColliderState.Colliding;
            foreach (Collider colid in colliders)
            {
                Debug.Log(colid);
            }
            Debug.Log("We hit something");
        }

        else
        {
            _state = ColliderState.Open;
        }
        
        _state = colliders.Length > 0 ? ColliderState.Colliding : ColliderState.Open;
    }
    private void Update()
    {
        if (_state == ColliderState.Open)
        {
            hitboxUpdate();
        }
    }
}
