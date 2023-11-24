﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Chara : MonoBehaviour
{
    private Rigidbody chara;
    public Text scoring;
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

        scoring.text = score.ToString();

        if ((Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began && grounded) || (Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began && oneMore))
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
            oneMore = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OneMore"))
        {
            oneMore = false;
        }
    }

    void Dead()
    {
        
    }

}