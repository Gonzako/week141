using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class simpleSidewaysMovement : MonoBehaviour, IPlayerVelocity
{
    public bool lookingRight => side > 0;
    public float maxVelocity => horizontalVelocity;

    [SerializeField]
    private float horizontalVelocity = 2;
    //public float dragWhenSlowingDown = 10;

    private Rigidbody2D rb;
    private float side;


    //private float oldDrag;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //oldDrag = rb.drag;
    }

    private void Update()
    {
        side = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(side*horizontalVelocity, rb.velocity.y);
        //Debug.Log(rb.velocity);
    }
}
