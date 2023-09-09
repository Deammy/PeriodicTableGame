using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeemMovement : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;
    public GameObject theNPC;
    public bool IsCharIdle = true;
    public bool GoBack = false;
    public HPBoss a;
    private Shake shake;




    
    public bool mons1killed = false;

    // Start is called before the first frame update
    void Start()
    {
        a = FindObjectOfType<HPBoss>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        Debug.Log(a.AtkAnim);   
        
    }

    // Update is called once per frame
    void Update()
    {   

        // 1st monster
        if (a.AtkAnim == true)
        {
            while (transform.position != Positions[0].transform.position )
            {
                StartCoroutine(Animplay());
            }          

        }

        if (transform.position == Positions[0].transform.position)
        {
            GoBack = true;
        }
        
        if (GoBack == true)
        {

            StartCoroutine(GoBackHit()); 

        }
        
        if (transform.position == Positions[1].transform.position)
        {

            GoBack = false;

        }

        if (a.NoHit == true)
        {
            StartCoroutine(NoHit()); 
        }


    }

    public void NoHitFunc(){
        StartCoroutine(HitAnimAfterFlme());
    }

    IEnumerator Animplay()
    {   
        theNPC.GetComponent<Animator>().Play("Player_Attack");
        transform.position = Vector3.MoveTowards(transform.position, Positions[0].transform.position, ObjectSpeed * Time.deltaTime );
        yield return new WaitForSeconds(0);
    }

    IEnumerator GoBackHit()
    {
        transform.position = Vector3.MoveTowards(transform.position, Positions[1].transform.position, ObjectSpeed * Time.deltaTime );
        if (transform.position == Positions[1].transform.position & a.BossBlood > 0 )
        {   
            theNPC.GetComponent<Animator>().Play("Player_Idle");

            yield return new WaitForSeconds(1);  

            theNPC.GetComponent<Animator>().Play("Player_Hitten");
            shake.CamShake();
        
            yield return new WaitForSeconds(1);
            
            theNPC.GetComponent<Animator>().Play("Player_Idle");
        }else if (transform.position == Positions[1].transform.position){
            theNPC.GetComponent<Animator>().Play("Player_Idle");
        }
    }


    IEnumerator NoHit()
    {

        yield return new WaitForSeconds(2);  

        theNPC.GetComponent<Animator>().Play("Player_Hitten");
        shake.CamShake();
        yield return new WaitForSeconds(1);
            
        theNPC.GetComponent<Animator>().Play("Player_Idle");

    }

    IEnumerator HitAnimAfterFlme()
    {
        theNPC.GetComponent<Animator>().Play("Player_Hitten");
        shake.CamShake();
        yield return new WaitForSeconds(1);
        theNPC.GetComponent<Animator>().Play("Player_Idle");

    }

    IEnumerator TimeDelay(int i)
    {   

        yield return new WaitForSeconds(i);
    }
}
