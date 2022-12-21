using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]  private GameObject[] marks;
    private int MarksIndex = 0;

    [SerializeField] private float speed = 2f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(marks[MarksIndex].transform.position, transform.position) < .1f)
        {
            MarksIndex = MarksIndex + 1;
            if(MarksIndex >= marks.Length)
            {
                MarksIndex = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, marks[MarksIndex].transform.position, Time.deltaTime * speed);
    }
}
