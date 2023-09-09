using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy_slime : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public HPBoss a;
    public GameObject theNPC;
    public ParticleSystem[] EffectSkills;
    private Shake shake;


    void Start()
    {   
        a = FindObjectOfType<HPBoss>();
        Debug.Log(a.AtkAnim);  
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a.SlimeHitten == true)
        {
            StartCoroutine(GetHit());
        }

        if(a.SlimeHitten == false)
        {
            StartCoroutine(backToIdle());
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            theNPC.GetComponent<Animator>().Play("Slime_Hitten");
            
        }
                
    }

    IEnumerator GetHit()    
    {     
        theNPC.GetComponent<Animator>().Play("Slime_Hitten");
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EffectSkills[0].Play();
        shake.CamShake();
        
    }

    IEnumerator backToIdle()
    {
        yield return new WaitForSeconds(0);
        if (a.SlimeHitten == false)
        {
            
            theNPC.GetComponent<Animator>().Play("Slime_idle");

        }

    }

    
   

    IEnumerator TimeDelay(int i)
    {
        yield return new WaitForSeconds(i);

    }


}
