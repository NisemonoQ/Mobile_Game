using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Spikes : MonoBehaviour
{
    public GameObject player;
    public Chara p; 
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
            p.alive = false;
            p.score = 0f; 
            player.SetActive(false);
           
            Debug.Log("He is dead");

            UI.GetComponent<UIScript>().ButtonEmpty();
            //Invoke("ReloadScene", attend);
         }
    }
}
