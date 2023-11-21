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


    void LateUpdate()
    {
        Vector2 ext = new Vector2(target.position.x + offset.x, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, ext, 5f * Time.deltaTime);
    }
}
