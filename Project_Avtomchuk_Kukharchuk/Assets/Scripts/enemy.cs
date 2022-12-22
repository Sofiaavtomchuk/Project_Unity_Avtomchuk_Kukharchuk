using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public Transform player;

    public float speed;
    public float agroDistance;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animation>();
        


    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer < agroDistance)
        {
            StartHurting();
        }
        else { StopHurting(); }      

    }

    void StartHurting()
    {
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
            
        }
        else if (player.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
            
        }
    }

    void StopHurting()
    {
        rb.velocity = new Vector2(0, 0);
    }
  


}
