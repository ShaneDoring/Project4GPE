using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed=3;
    public float jumpForce=5;
    public int maxJumps = 1;
    public int currentJumps;
    public float height = 1.1f;

    public AudioClip jumpClip;
    public AudioSource audioSource;

    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
      

        currentJumps = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal")*speed;
        

        animator.SetFloat("xMove", Mathf.Abs(xMovement));
       

        rigidBody.velocity = new Vector2(xMovement, rigidBody.velocity.y);

       /* if (rigidBody.velocity.x != 0)
        {
            animator.Play("PlayerWalk");
        }
        else
        {
            animator.Play("PlayerIdle");
        }
       */

        if (rigidBody.velocity.x > 0)
        {
            sprite.flipX = false;
        }
        if (rigidBody.velocity.x < 0)
        {
            sprite.flipX = true;
        }


        //jump 
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                currentJumps = maxJumps;
            }
            if (currentJumps > 0)
            {
                Jump();
            }
                audioSource.clip = jumpClip;
                audioSource.Play();
            
        }

        
    }
    void Jump()
    {
       currentJumps--;
        animator.SetTrigger("Jump");
        animator.SetBool("Jump1",true);
        // rigidBody.AddForce(Vector2.up * jumpForce);
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        
    }
   /* bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, (height / 2f) * 0.1f);

        return (hitInfo.collider!=null);
    }*/
   private bool IsGrounded()
    {
        float extraHeighttext = .1f;
       RaycastHit2D raycastHit= Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y+extraHeighttext);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeighttext), rayColor);
        Debug.Log(raycastHit.collider);
        bool grounded= raycastHit.collider != null;
        animator.SetBool("isGrounded", grounded);
        animator.SetBool("Jump1", false);
        return grounded;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IsGrounded();
    }
}
