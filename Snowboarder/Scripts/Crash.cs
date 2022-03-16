using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    CircleCollider2D playerHead;

    [SerializeField] float crashDelay = 1f;

    [SerializeField] ParticleSystem crashEffect;

    [SerializeField] AudioClip crashSFX;

    bool isCalled = false;

    void Start() 
    {
        isCalled = false;
        playerHead = GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            if(!isCalled)
            {
                FindObjectOfType<PlayerController>().DisableControls();
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSFX);
                Invoke("crashSceneReload", crashDelay);
            }
            isCalled = true;
        }
    } 

    void crashSceneReload()
    {
        SceneManager.LoadScene(0);
    }
}
