using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamM : MonoBehaviour
{
    public Transform target;
    Vector2 offset; 

    void Start()
    {
        offset = transform.position - target.position;
    }


    void Update()
    {
        Vector3 ext = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = ext; 
    }
}
