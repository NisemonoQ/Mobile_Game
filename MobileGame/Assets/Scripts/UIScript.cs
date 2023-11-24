using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    [SerializeField] GameObject empty;
    [SerializeField] string CurrentScene;

    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().name;      
    }


    public void Restart()
    {
        SceneManager.LoadScene(CurrentScene);
    }

    public void ButtonEmpty()
    {
        empty.SetActive(true);
    }
}
