using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoveLeft : MonoBehaviour
{
    public int MoveStart;
    public GameObject MoveDisplay;
    public GameObject ExtraMove;
    public HealthBar healthBar;
    public GameObject theNPC;
    public SkillItem Skill;
    private Shake shake;
    private PeemMovement PeemMovement;

    public void Start(){
        MoveDisplay.GetComponent<Text>().text = "" + MoveStart;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        PeemMovement = GameObject.FindObjectOfType<PeemMovement>();
    }

    public void MoveLefting(){
        
        MoveStart = MoveStart - Random.Range(18,22) + Skill.Heal + Skill.ItemBlock;
        if(MoveStart > 100){
            MoveStart = 100;
        }
        TakeDamage();
        MoveDisplay.GetComponent<Text>().text = "" + MoveStart;
    }
    
    void TakeDamage()
    {
        healthBar.SetHealth(MoveStart);
        if(MoveStart > 0){
            shake.CamShake();
            PeemMovement.NoHitFunc();

        }

        if(MoveStart <= 0)
        {
            MoveStart = 0;
            SceneManager.LoadScene("gameover");
        }
    }
}
