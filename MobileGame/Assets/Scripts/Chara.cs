using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpHeight = 10.0f;
    public float speed = 7.0f;
    private bool grounded = true;
    private bool jumpregister = false;
    private GameObject ground;
    public GameObject Enemy;
    public float fall;
    private Animator playerAnimator;
    public float shortfall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            jumpregister = true;
        }
    }

    void FixedUpdate()
    {
        Vector2 move = Vector2.right * Input.GetAxisRaw("Horizontal") * speed;
        move.y = rb.velocity.y;
        if (jumpregister)
        {
            move.y = CalculateJumpForce();
            jumpregister = false;
            playerAnimator.SetTrigger("Jump");
            //grounded = false;
        }
        Debug.DrawRay(rb.position, move, Color.green);

        if (move.y < -Mathf.Epsilon)
        {
            Debug.Log("Descente");
            move.y += Physics2D.gravity.y * rb.gravityScale * fall * Time.deltaTime;
        }
        if (!grounded)
        {
            //Descente : 
            if (move.y < 0f)
            {
                move.y += Physics2D.gravity.y * rb.gravityScale * fall * Time.deltaTime;
            }
            //On monte et la touche est relach�e : la gravit� est plus forte (on monte donc moins haut)
            else if (!Input.GetButton("Jump"))
            {
                move.y += Physics2D.gravity.y * rb.gravityScale * shortfall * Time.deltaTime;
            }
        }

        rb.velocity = move;
    }

    private float CalculateJumpForce()
    {

        float jumpImpulse = Mathf.Sqrt(-2f * Physics2D.gravity.y * rb.gravityScale * jumpHeight);

        return jumpImpulse;
    }
}