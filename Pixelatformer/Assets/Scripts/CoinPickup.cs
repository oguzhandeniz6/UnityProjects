using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] float volume = 1f;
    [SerializeField] int points = 10;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, volume);
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddScore(points);
        }
    }
}
