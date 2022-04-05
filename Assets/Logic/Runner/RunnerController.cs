using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Animations;

public class RunnerController : MonoBehaviour
{

    [SerializeField] private LayerMask platformMask;
        
    public Rigidbody2D rb;
    public float jumpForce;
    private BoxCollider2D _boxCollider2D;
    private Animator myAnimator;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }


    private bool IsGrounded()
    {
        float extraHeightText = .5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down,
            _boxCollider2D.bounds.extents.y + extraHeightText, platformMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        
        Debug.DrawRay(_boxCollider2D.bounds.center, Vector2.down * (_boxCollider2D.bounds.extents.y + extraHeightText), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    private void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (!IsGrounded())
        {
            myAnimator.SetBool("Jumping",true);
        }
        else
        {
            myAnimator.SetBool("Jumping",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
