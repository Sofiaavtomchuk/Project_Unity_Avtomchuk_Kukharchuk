using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private AudioSource finishMusic;
    // Start is called before the first frame update
    void Start()
    {
        finishMusic = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            finishMusic.Play();
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {

    }
}
