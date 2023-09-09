using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject[] ImpactEffect;
    //public ParticleSystem Effect;
    //public GameObject Effect1;

    private Rigidbody2D Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Rigidbody.velocity = transform.right * projectileSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        /*if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
        Instantiate(ImpactEffect[0], transform.position, Quaternion.identity);
        //Instantiate(ImpactEffect[1], transform.position, Quaternion.identity);
       // Effect.Play();
        Destroy(gameObject);
        
        //Destroy(impactEffect.gameObject);
        Debug.Log("trigger");
    }



    
}
