using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            Invoke("ReloadScene", 4f);
            GetComponent<AudioSource>().Play();
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
