using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strawberry : MonoBehaviour
{
    [SerializeField] private AudioSource strawberryMusic;
    private int Strawberries = 0;


    [SerializeField] private Text countStrawberries;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Strawberry"))
        {
            strawberryMusic.Play();
            Destroy(collision.gameObject);
            Strawberries = Strawberries + 1;
            //Debug.Log("Strawberris: " + Strawberries);
            countStrawberries.text = ": " + Strawberries;
        }
    }
}
