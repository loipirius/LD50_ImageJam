using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 1000f;
    public Rigidbody2D rb;
    private BoxCollider2D _boxCollider2D;
    public LayerMask platformMask;
    private Animator myAnimator;

    private float moveX;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        float extraHeightText = .5f;
        RaycastHit2D boxcastHit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,
            Vector2.down, extraHeightText, platformMask); 
        /*RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down,
            _boxCollider2D.bounds.extents.y + extraHeightText, platformMask);*/
        Color rayColor;
        if (boxcastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        
        Debug.DrawRay(_boxCollider2D.bounds.center, Vector2.down * (_boxCollider2D.bounds.extents.y + extraHeightText), rayColor);
        Debug.Log(boxcastHit.collider);
        return boxcastHit.collider != null;
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        if ((IsGrounded() && Input.GetKeyDown(KeyCode.Space)))
        {
            Debug.Log("jumping");
            rb.velocity = Vector2.up * jumpForce;
        }

        if (IsGrounded())
        {
            myAnimator.SetBool("Grounded", true);
            myAnimator.SetBool("Jumping", false);
        }
        else
        {
            myAnimator.SetBool("Grounded", false);
            myAnimator.SetBool("Jumping", true);
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;
    }
}
