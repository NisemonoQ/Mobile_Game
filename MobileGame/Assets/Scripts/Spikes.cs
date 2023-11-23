using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spikes : MonoBehaviour
{
    public GameObject player;
    float attend = 5f;
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

    private void Update()
    {
        if(player.activeSelf == false)
        {
            attend -= 1.5f * Time.deltaTime; 
        }

        if(attend <= 0f)
        {
            SceneManager.LoadScene("Test LD 1", LoadSceneMode.Single);
        }
    }

}
