using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class playerGroundCheck : MonoBehaviour, ICheckGround
{

    public LayerMask whatIsGround;
    public float castRadious = 1f;
    public float downDistance = 0.5f;

    RaycastHit2D castResult;
    RaycastHit2D prevCastResult;

    public bool areWeGrounded => castResult.collider != null;

    public event Action onTouchGround;
    public GameEvent onGroundTouched;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        castResult = Physics2D.CircleCast(transform.position, castRadious, Vector2.down, downDistance, whatIsGround);
        if(prevCastResult.collider == null && castResult.collider != null)
        {
            onTouchGround?.Invoke();
        }

        prevCastResult = castResult;
    }

    void OnDrawGizmosSelected()
    {
        if (castResult)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * castResult.distance);
            Gizmos.DrawWireSphere(transform.position + Vector3.down * castResult.distance, castRadious);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (downDistance + castRadious));
            Gizmos.DrawWireSphere(transform.position + Vector3.down * downDistance, castRadious);
        }
    }
}
