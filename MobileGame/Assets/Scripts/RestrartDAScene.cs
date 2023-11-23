using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RestrartDAScene : MonoBehaviour
{

    private string CurrentScene;
    void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(CurrentScene);
        }
    }
}
