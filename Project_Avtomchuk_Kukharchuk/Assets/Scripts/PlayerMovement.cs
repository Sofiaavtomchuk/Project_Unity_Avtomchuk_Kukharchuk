using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //int num = 16;
    private float move = 0f;
    private Rigidbody2D rb;

    private BoxCollider2D bc;
    //bool boolean = false;
    public float speed = 8f;
    public float jump = 12f;

    private Animator animator;
    private SpriteRenderer flip;



    [SerializeField] private LayerMask jumpGround;

    private enum MovementState {idle, run, jump, falling }
    private MovementState state = MovementState.idle;


    [SerializeField] private AudioSource jumpMusic;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        flip = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
     void Update()
     {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpMusic.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector3(rb.velocity.x, jump);
        }

        Animatione();
     }

    private void Animatione()
    {
        MovementState state;
        if (move > 0f)
        {
            state = MovementState.run;
            flip.flipX = false;
        }
        else if (move < 0f)
        {
            state = MovementState.run;
            flip.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        animator.SetInteger("state", (int)state);

       
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpGround);
    }
}
