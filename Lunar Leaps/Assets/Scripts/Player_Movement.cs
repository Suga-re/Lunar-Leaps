using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float horizontal;
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    private bool isFacingRight = true;
    private bool isAlive = true;
    private float halfscreenWidth = 8.0f;
    private float contJumps = 0;



    [SerializeField] private Rigidbody2D player_rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private Animator animator;

    void OnBecameInvisible()
    {
        triggerGameOver();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal * speed));

        if (JumpStatus() == "canjump" && isAlive) 
        {
            animator.SetBool("isJumping", true);
            contJumps += 1;
            player_rb.velocity = new Vector2(player_rb.velocity.x, jumpStrength);
            
        }
        if (JumpStatus()=="jumpreleased")
        {
            if(player_rb.velocity.y > 0 && isAlive)
            {
                player_rb.velocity = new Vector2(player_rb.velocity.x, player_rb.velocity.y * 0.5f);
            }
            
        }
        if (IsGrounded())
        {
            contJumps = 0;
            animator.SetBool("isJumping", false);
        }
   
        MovePlayer();

    }


    private void FixedUpdate()
    {

        player_rb.velocity = new Vector2(horizontal * speed, player_rb.velocity.y);
        if (!InScreenHorizontal())
        {
            player_rb.velocity = new Vector2(0,0);
        }

    }
    
    private void MovePlayer()
    {
        if (IsFacingWrongDirection()) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }



    private string JumpStatus()
    {
        if (Input.GetButtonDown("Jump") == true && contJumps < 2)
        {
            return "canjump";
        }
        if (Input.GetButtonUp("Jump") == true)
        {
            return "jumpreleased";
        }
        else { return ""; }

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);
    }

    private bool IsFacingWrongDirection()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            return true;
        }
        else { return false; }
    }

    private bool InScreenHorizontal()
    {
        if (transform.position.x <= -1 * halfscreenWidth && !isFacingRight)
        {
            return false;
        }
        if (transform.position.x >= halfscreenWidth && isFacingRight)
        {
            return false;
        }
        return true;
    }


    private void triggerGameOver()
    {
        isAlive = false;
        //TO DO
    }
}


