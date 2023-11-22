using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    private Rigidbody chara;
    

    //Vector2 beyond;

    public float laneDistance;
    public float jumpHeight;
    public float moveSpeed;
    public int gray;

    public float heightForce = 5f; 

    private bool grounded; 
    public LayerMask mask; 



    void Start()
    {
        chara = GetComponent<Rigidbody>();
        
        gray = -1;
        //beyond = transform.position;

    }

    private void Update()
    {
        chara.velocity = Vector3.right * moveSpeed ;
        Gravitas();

        if(Input.GetButtonDown("Jump") && grounded)
        {
            gray *= -1; 
        }
    }

    void Gravitas()
    {
        if(Physics.Raycast(transform.position, Vector3.up * gray, .6f, ~mask))
        {
            grounded = true;
           // Debug.Log("work");
        }

        else
        {
            grounded = false;
            chara.velocity += Vector3.up * gray * heightForce;

        }
    }


    /* private void Update()
     {
         beyond.x = moveSpeed;
         Debug.Log(chara.isGrounded);

         if (gray == true)
         {
             beyond.y += badGravity * Time.deltaTime;
         }

         if(gray == false)
         {
             beyond.y += goodGravity * Time.deltaTime;
         }

         transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

         if (Input.GetButtonDown("Jump"))
         {
             gray = false;
             Gravitas();
             //Debug.Log("why");

         }

         if(gray == false  && Input.GetButtonDown("Fire1"))
         {
             gray = true;
             Gravitas();

         }

         //Vector2 targetPosition = transform.position.x * transform.right + transform.position.y * transform.up;
        // transform.position = Vector2.Lerp(transform.position, targetPosition, 50f * Time.deltaTime);
     }

     void Gravitas()
     {
         if(gray == true)
         {
             beyond.y = jumpHeight;
         }


         if(gray == false)
         {
             beyond.y = -jumpHeight; 
         }
     }

     private void FixedUpdate()
     {
         //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
         chara.Move(beyond * Time.fixedDeltaTime);
     }*/

}