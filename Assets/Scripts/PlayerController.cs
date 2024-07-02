using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpImpulse = 8f;
    public float airWalkSpeed = 3f;
    Vector2 moveInput;

    TouchingDirections touchingDirections;

    public float CurrentMoveSpeed {  get
        {
            if (touchingDirections.IsGrounded)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    return walkSpeed;
                }
                else
                {
                    //Air move
                    return airWalkSpeed;
                }
            }
            else
            {
                //idle speed is 0
                return 0;
            }
        } }



    private bool _isMoving =  false;

    public bool IsMoving { get
        {
            return _isMoving;
        } private set 
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight { get { 
            return _isFacingRight;
        } private set { 
            //Flip only if value is new
            if(_isFacingRight != value)
            {
                //flip local scale to make player face opposite
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    Rigidbody2D rb;
    Animator animator;
 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            //Face right
            IsFacingRight = true;
        } else if(moveInput.x < 0 && IsFacingRight)
        {
            //Face left
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //TODO check if alive as well
        if(context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);

            AudioManager.instance.Play("Jump");
        }
    }

}
