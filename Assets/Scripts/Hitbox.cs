using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public LayerMask mask;
    //public bool useSphere = false;
    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidingColor;
    public Collider[] colliders;
    public Vector3 boxSize;
    private ColliderState _state;
    private IHitboxResponder _responder = null;

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
    private void OnDrawGizmos()
    {
        checkGizmoColor();
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, boxSize.z * 2)); // Because size is halfExtents
    }
    public void startCheckingCollision()
    {
        _state = ColliderState.Open;
    }

    public void stopCheckingCollision()
    {
        _state = ColliderState.Closed;
    }
    private void Start()
    {
        
    }
    public void hitboxUpdate()
    {
        if (_state == ColliderState.Closed) { return; }
        Collider[] colliders = Physics.OverlapBox(transform.position, boxSize, transform.rotation, mask);

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
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider aCollider = colliders[i];
            _responder?.collisionedWith(aCollider);
        }

        _state = colliders.Length > 0 ? ColliderState.Colliding : ColliderState.Open;
    }

    public void useResponder(IHitboxResponder responder)
    {
        _responder = responder;
    }
}

