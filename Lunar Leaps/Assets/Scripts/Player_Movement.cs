using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float horizontal;
    public float speed = 5.0f;
    public float jumpStrength = 10.0f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D player_rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask platformLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") == true && IsGrounded())
        {
            player_rb.velocity = new Vector2(player_rb.velocity.x, jumpStrength);
        }
        if (Input.GetButtonUp("Jump") == true && player_rb.velocity.y > 0)
        {
            player_rb.velocity = new Vector2(player_rb.velocity.x, player_rb.velocity.y*0.5f);
        }
   
        FlipPlayer();

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);
    }
    private void FixedUpdate()
    {
        player_rb.velocity = new Vector2(horizontal * speed, player_rb.velocity.y);
    }
    
    private void FlipPlayer()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}


