using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chara : MonoBehaviour
{
    private CharacterController chara;
    GameObject perso;

    Vector2 beyond;

    public float laneDistance = 4f;
    public float jumpHeight = 5f;
    float moveSpeed = 2f; 

    void Start()
    {
        chara = GetComponent<CharacterController>();

    }

    private void Update()
    {
        beyond.x = moveSpeed;

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            Gravitas();
        }

        Vector2 targetPosition = transform.position.x * transform.right + transform.position.y * transform.up;
        transform.position = Vector2.Lerp(transform.position, targetPosition, 50f * Time.deltaTime);
    }

    void Gravitas()
    {

    }

    private void FixedUpdate()
    {
        //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        //chara.Move(beyond * Time.fixedDeltaTime);
    }

}