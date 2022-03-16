using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;

    [SerializeField] float delay = 0.0f;

    [SerializeField] Color32 fullColor = new Color32(1, 0, 0, 1);
    [SerializeField] Color32 emptyColor = new Color32(1, 1, 0, 1);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package")
        {
            if(hasPackage)
            {
                Debug.Log("You already have a package");
            }
            else
            {
                Debug.Log("Package picked up");
                hasPackage = true;

                Destroy(other.gameObject, delay);

                spriteRenderer.color = fullColor;
            }
            
        }

        if(other.tag == "Customer")
        {
            if(hasPackage)
            {
                Debug.Log("Package delivered");
                hasPackage = false;

                spriteRenderer.color = emptyColor;
            }
            else
            {
                Debug.Log("You don't have a package");
            }
        }
    }
}
