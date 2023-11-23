using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public Chara fraud;
    MeshRenderer coin;

    public float timing = 5f;

    private void Start()
    {
        coin = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fraud.score += 1;
            //coin.enabled = false;
            Destroy(gameObject);            
            Debug.Log(fraud.score);            
        }
    }

    /*private void Update()
    {
        timing -= 1f * Time.deltaTime; 
        if(timing<=0f)
        {
            timing = 5f; 
            Destroy(gameObject);
        }

    }*/

}
