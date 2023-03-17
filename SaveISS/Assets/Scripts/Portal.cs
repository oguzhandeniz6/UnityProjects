using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isSecond;

    public float distance = 0.2f;

    void Start()
    {
        destination = isSecond == false ? 
        destination = destination = GameObject.FindGameObjectWithTag("Second Portal").GetComponent<Transform>() :
        destination = GameObject.FindGameObjectWithTag("First Portal").GetComponent<Transform>();
        
    }

    void Update()
    {
        destination = isSecond == false ? 
        destination = destination = GameObject.FindGameObjectWithTag("Second Portal").GetComponent<Transform>() :
        destination = GameObject.FindGameObjectWithTag("First Portal").GetComponent<Transform>();
    }
    
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            if (Vector2.Distance(transform.position, other.transform.position) > distance)
            {
                other.transform.position = new Vector2 (destination.position.x, destination.position.y);
            }
        }
    }
}
