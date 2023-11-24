using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Chara : MonoBehaviour
{
    [SerializeField] FMOD.Studio.EventInstance music;
    [SerializeField] UIScript script;
    [SerializeField]Transform charaTP;
    [SerializeField] Transform StrartingPoint;


    private Rigidbody chara;
    public Text scoring;
    //Vector2 beyond;

    public float laneDistance;
    public float jumpHeight;
    public float moveSpeed;
    public int gray;

    public float score = 0f;


    private bool oneMore;
    public bool alive = true;

    public float heightForce = 5f; 

    private bool grounded; 
    public LayerMask mask; 



    void Start()
    {
        chara = GetComponent<Rigidbody>();
        score = 0f;
        gray = -1;

        charaTP = GetComponent<Transform>();

       music = FMODUnity.RuntimeManager.CreateInstance("event:/Musique 2.0");
       music.start();
        //beyond = transform.position;

    }

    private void Update()
    {
        chara.velocity = Vector3.right * moveSpeed ;
        Vector3 noVelocity = new Vector3(0f, 0f, 0f);
        Gravitas();

        scoring.text = score.ToString();
        music.setParameterByName("VARIABLE COUNT",score);

        if ((Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began && grounded) || (Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began && oneMore))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jump");
            gray *= -1; 
        }
    }

    void Gravitas()
    {
        if(Physics.Raycast(transform.position, Vector3.up * gray, .6f, ~mask))
        {
            grounded = true;
            
            //Debug.Log("work");
        }

        else
        {
            grounded = false;
            //FMODUnity.RuntimeManager.PlayOneShot("event:/Landing");
            chara.velocity += Vector3.up * gray * heightForce;
            //Debug.Log("dont");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("OneMore"))
        {
            oneMore = true;
        }

        if(other.CompareTag("Spikes"))
        {
            //music.setParameterByName("VARIABLE COUNT", 0);
            music.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if(other.CompareTag("Teleport"))
        {
            charaTP.position = StrartingPoint.position;
            Debug.Log("dont");

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OneMore"))
        {
            oneMore = false;
        }
    }

    void Dead()
    {
        
    }

}