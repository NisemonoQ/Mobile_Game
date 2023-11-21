using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    Rigidbody2D rb;
    Transform cha; 
    private Vector2 toTheTop;
    public float moving = 10f;

    bool jumpregister; 

    bool up = false;
    bool down = true;

    bool grounded = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cha = GetComponent<Transform>();
    }

    private void Update()
    {
        /*toTheTop.x = moving;
        toTheTop.y = cha.position.y;

        Vector2 targetPosition = transform.position.x * transform.right;
        transform.position = Vector2.Lerp(transform.position, targetPosition, moving * Time.deltaTime);*/
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(toTheTop * Time.deltaTime);
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
