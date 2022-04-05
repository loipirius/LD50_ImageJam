using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    public float playerSpeed;
    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private Vector2 movement;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        _animator.SetFloat("Horizontal", movement.x);
        if (movement.x > 0) _renderer.flipX = true; else _renderer.flipX = false;
        
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
