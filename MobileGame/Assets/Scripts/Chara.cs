using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    private CharacterController chara;
    GameObject perso;

    Vector2 beyond;

    public float laneDistance;
    public float jumpHeight;
    public float moveSpeed;

    public float goodGravity;
    public float badGravity; 

    public bool gray; 



    void Start()
    {
        chara = GetComponent<CharacterController>();
        gray = true;

    }

    private void Update()
    {
        beyond.x = moveSpeed;
        

        if(gray == true)
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
            Debug.Log("why");

            Debug.Log(chara.isGrounded);
        }

        if(gray == false  && Input.GetButtonDown("Fire1"))
        {
            gray = true;
            Gravitas();
            Debug.Log("because");
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
    }

}