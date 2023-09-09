using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillItem : MonoBehaviour
{
    public int ItemDamage,Burn,Turn = 2,ItemBlock,Heal;
    public bool SwordConfirm,PotionConfirm,ShieldConfirm,FlameConfirm;
    public ElementPick GroupCheck;
    public bool IsFlameSelected = false;

    void Start(){
        ItemBlock = 0;
        ItemDamage = 0;
        Heal = 0;
        Burn = 0;
    }

    public void AllSkill(int i){
        if(SwordConfirm == true && GroupCheck.GroupCheck == true)
        {
            Sword(i);
        }
        else
        {
            SwordConfirm = false;
        }
        if(FlameConfirm == true && GroupCheck.GroupCheck == true)
        {
            Flame(i);
            StartCoroutine(FlameCheck());
        }
        else if(FlameConfirm == true && Turn == 1)
        {
            Flame(i);
        }
        else
        {
            FlameConfirm = false;
        }

        if(PotionConfirm == true && GroupCheck.GroupCheck == true)
        {
            Potion(i);
        }
        else
        {
            PotionConfirm = false;
        }
        if(ShieldConfirm == true && GroupCheck.GroupCheck == true)
        {
            Shield(i);
        }
        else{
            ShieldConfirm = false;
        }
    }
    void Sword(int i){
        if(i != 0){
            ItemDamage = 20/i;
            SwordConfirm = false;  
        }
    }
    void Flame(int i){
        if(i != 0){
            Burn = Random.Range(10,15)/i;

            Turn = Turn-1; 
            if(Turn == 1){
                ItemDamage = 10/i;
            }
            if(Turn == 0){
                FlameConfirm = false;
                Turn = 2;
            }
        }
    }
    void Shield(int i){
        if(i != 0){
            ItemBlock = 20/i;
           
            ShieldConfirm=false;
        }
    }
    void Potion(int i){
        if(i != 0){
           Heal = Random.Range(25,30)/i;
           
            PotionConfirm = false; 
        }
        
    }


    public void SkillPick(int i){
        if(i == 1){
            SwordConfirm = true;
            FlameConfirm = false;
            ShieldConfirm = false;
            PotionConfirm = false;
        }
        if(i == 2){
            SwordConfirm = false;
            FlameConfirm = true;
            ShieldConfirm = false;
            PotionConfirm = false;
        }
        if(i == 3){
            SwordConfirm = false;
            FlameConfirm = false;
            ShieldConfirm = true;
            PotionConfirm = false;
        }
        if(i == 4){
            SwordConfirm = false;
            FlameConfirm = false;
            ShieldConfirm = false;
            PotionConfirm = true;
        }
    }

    IEnumerator FlameCheck()
    {
        IsFlameSelected = true;
        yield return new WaitForSeconds(1);
        IsFlameSelected = false;
        

        
    }
}
