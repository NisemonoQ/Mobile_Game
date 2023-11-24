using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Collectibles : MonoBehaviour
{
    public Chara fraud;
    //[SerializeField] FMOD.Studio.EventInstance music;


    private void Start()
    {
        fraud.score = 0;
       // music = FMODUnity.RuntimeManager.CreateInstance("event:/Musique 2.0");
        //music.start();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Item");
            fraud.score += 1;
            fraud.scoring.text = fraud.score.ToString();
            //music.setParameterByName("VALUABLE COUNT", fraud.score);

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
