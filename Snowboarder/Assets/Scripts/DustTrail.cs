using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;

   void OnCollisionEnter2D(Collision2D other) 
   {
       if(other.gameObject.tag == "Ground")
       {
           trailEffect.Play();
       }
   }
   
   void OnCollisionExit2D(Collision2D other) 
   {
       if(other.gameObject.tag == "Ground")
       {
           trailEffect.Stop();
       }
   }
}
