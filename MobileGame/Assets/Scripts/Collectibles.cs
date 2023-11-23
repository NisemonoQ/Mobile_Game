using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public Chara fraud;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fraud.score += 1;
            //gameObject.SetActive(false);            
            Debug.Log(fraud.score);
            
        }
    }
}
