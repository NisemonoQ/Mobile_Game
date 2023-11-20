using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 toTheTop;
    public float moving = 10f;

    bool jumpregister; 

    bool up = false;
    bool down = true;

    bool grounded = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 move = Vector2.right * Input.GetAxisRaw("Horizontal") * moving;
        move.y = rb.velocity.y;

        if(jumpregister)
        {
            
        }

        rb.velocity = move;
    }

    void Gravitas()
    {
        
    }


}
