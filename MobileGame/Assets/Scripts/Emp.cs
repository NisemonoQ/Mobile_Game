using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emp : MonoBehaviour
{
    public GameObject player;
    //public MeshRenderer playerMesh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            //playerMesh.enabled = false; 

            Debug.Log("He is dead");
        }
    }
}

