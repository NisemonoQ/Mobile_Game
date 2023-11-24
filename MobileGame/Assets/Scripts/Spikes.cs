using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Spikes : MonoBehaviour
{
    public GameObject player;
    public float attend = 3f;

    [SerializeField] GameObject UI; 

    private string ThisScene;

    //public MeshRenderer playerMesh;


    private void Start()
    {
        ThisScene = SceneManager.GetActiveScene().name; 
    }

    private void OnTriggerEnter(Collider other)
    {
         if(other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Mort");
            player.SetActive(false);
            //playerMesh.enabled = false;             
            Debug.Log("He is dead");


            UI.GetComponent<UIScript>().ButtonEmpty();
            //Invoke("ReloadScene", attend);


        }
    }
}
