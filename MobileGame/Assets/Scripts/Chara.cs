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

    public int score = 0;


    private bool oneMore;

    public float heightForce = 5f; 

    private bool grounded; 
    public LayerMask mask; 



    void Start()
    {
        chara = GetComponent<Rigidbody>();
        score = 0;
        gray = -1;
        //beyond = transform.position;

    }

    private void Update()
    {
        chara.velocity = Vector3.right * moveSpeed ;
        Vector3 noVelocity = new Vector3(0f, 0f, 0f);
        Gravitas();

        if(Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began && grounded)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
            gray *= -1; 
        }

        if(chara.velocity == noVelocity)
        {
            Dead();
        }
    }

    void Gravitas()
    {
        if(Physics.Raycast(transform.position, Vector3.up * gray, .6f, ~mask))
        {
            grounded = true;
            
            //Debug.Log("work");
        }

        else
        {
            grounded = false;
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Landing");
            chara.velocity += Vector3.up * gray * heightForce;
            //Debug.Log("dont");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("OneMore"))
        {
            OneMoreJump();
            Debug.Log("GOOOOOOOO");
        }

    }

    void OneMoreJump()
    {
        grounded = true; 
        oneMore = true; 
        if(oneMore == true /*&& Input.GetButtonDown("Jump")*/)
        {             
            // chara.velocity += Vector3.up * gray * heightForce;
            //grounded = false;
            gray *= -1;
            oneMore = false;
            Debug.Log("GOGOGO");
        }
    }

    void Dead()
    {
        
    }

}