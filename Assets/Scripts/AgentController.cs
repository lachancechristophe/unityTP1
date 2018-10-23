using System;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour {

    public float maxSpeed = 10f;

    private float rayonGround = 0.1f;
    private float jumpForce = 20f;
    private float lastFrameX, lastDeltaX;
    private float move;
    private bool isGrounded = false;
    private bool doubleJump = false;
    private bool icePhysics = false;

    private Vector2 lastVelocity;
    private Animator anim;
    private Rigidbody2D body;
    private SpriteRenderer sr;
    private BoxCollider2D standingCol, crouchingCol;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public LayerMask whatIsIce;
    // Use this for initialization
    void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        standingCol = transform.Find("StandCollider").gameObject.GetComponent<BoxCollider2D>();
        crouchingCol = transform.Find("CrouchCollider").gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
       // curVel = Vector3.Lerp(curVel, vel, 5 friction friction * Time.deltaTime);

        //Jump
        if (isGrounded)
            doubleJump = false;
        if (Input.GetButtonDown("Jump"))
            if (isGrounded)
                Jump();
            else if(!doubleJump)
            {
                doubleJump = true;
                Jump();
                anim.SetTrigger("doubleJump");
            }

        //Crouch
        if (Input.GetAxis("Vertical") < 0)  SetCrouched();
        if (Input.GetAxis("Vertical") >= 0) SetStanding();
    }

    private void Jump()
    {
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void SetCrouched()
    {
        anim.SetBool("crouched", true);
        standingCol.enabled = false;
        crouchingCol.enabled = true;
    }

    private void SetStanding()
    {
        anim.SetBool("crouched", false);
        standingCol.enabled = true;
        crouchingCol.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");

        if(icePhysics) body.AddForce(new Vector2(move * maxSpeed * 3, 0));
        else body.velocity = new Vector2(move * maxSpeed, body.velocity.y);
        flip(move);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, rayonGround, whatIsGround);
        icePhysics = Physics2D.OverlapCircle(groundCheck.position, rayonGround, whatIsIce);

        anim.SetFloat("Speed", Mathf.Abs(move));
        anim.SetBool("isGrounded", isGrounded);
    }

    private void flip(float move)
    {
        if (move > 0 && sr.flipX)
            sr.flipX = !sr.flipX;
        else if (move < 0 && !sr.flipX)
            sr.flipX = !sr.flipX;
    }
}
