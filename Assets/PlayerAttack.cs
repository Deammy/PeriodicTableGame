using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform firePosition;
    public GameObject projectile;
    public SkillItem Skill;
    float time;
    float timeLim;

     void Start(){
        time = 1f;
        //time = 3f;

        Skill = FindObjectOfType<SkillItem>();
        
     }

    // Update is called once per frame
    void Update()
    {
        
        
        if(Skill.IsFlameSelected == true & time == 1f)
        {
            time = 0f;
            Instantiate(projectile, firePosition.position, firePosition.rotation);
            //StartCoroutine(TimeDelay(3));
        }
        
    }

    IEnumerator TimeDelay(int i){
        yield return new WaitForSeconds(i);
    }

}
