using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;
    //public MeshRenderer playerMesh;

    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Mort");
            player.SetActive(false);
            //playerMesh.enabled = false; 
            
            Debug.Log("He is dead");
        }
    }
}
