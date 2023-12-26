using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private string currentState;
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    public bool isJumping;
    private bool isFacingRight = true;
    private bool doubleJump;
    private float MovementDetect;
    /*
    //for Wall Sliding
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;

    //for wall jumping
    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.02f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(2.5f, 7f);
    */
    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCoolDown = 1f;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer trailRenderer;
    //[SerializeField] private Transform wallCheck;
    //[SerializeField] private LayerMask wallLayer;

    //animation States
    //const string Jump = "jump";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded() && !Input.GetKey(KeyCode.Space))
        {
            doubleJump = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
            if (isGrounded() || doubleJump)
            {
                isJumping = true;
                
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;
            }
            
        }
        
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(Dash());
        }

        if(isGrounded())
        {
            animator.SetBool("isJumping", false);
        }


        /*
        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip();
        }
        */
        Flip();
    }

    private void FixedUpdate()
    {
        MovementDetect = Mathf.Abs(Input.GetAxisRaw("Horizontal") * speed);
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Speed", MovementDetect);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /*
    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(isWalled() && !isGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if(isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
                
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x = -1 * localScale.x;
                transform.localScale = localScale;
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
    */

    private IEnumerator Dash() 
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        trailRenderer.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
    /*
    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if(currentState == newState) return;

        //play animation
        animator.Play(newState);

        currentState = newState;
    }
    */
 
}
