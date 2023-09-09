using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CountDownTiming : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TimeDisplay;
    public HPBoss CalConfirm;
    public int SecondsGroup;
    public int SecondsGroupLeft;
    public bool CheckGroup = false;
    public int SecondsPick;
    public int SecondsPickLeft;
    public bool CheckPick = false;
    public bool TimeGroupConfirm = false;
    public bool GroupFailed = false;
    public bool CheckDelay = false;
    public int TimeCounting = 0;
    public AudioSource source1;
    public AudioSource source2;
    public ElementPick ElementPick;
    public Item Item;
    public ButtonColorR2AndR3 ButtonColorR2AndR3;
    public GroupOpen GroupOpen;
    public void Start()
    {
        TimeDisplay.GetComponent<Text>().text = "Ready";
    }

    void Update()
    {
        if(TimeGroupConfirm == true){
            if(SecondsGroupLeft >= 0 && CheckGroup == false){
                StartCoroutine(CountDownGroup());
            }
            if(TimeDisplay.GetComponent<Text>().text == "0"){
                if(ElementPick.GroupCheck == false){
                    TimeDisplay.GetComponent<Text>().text = "Stop";
                    TimeGroupConfirm = false;
                    source2.Play();
                    CalConfirm.CalConfirm = true;
                    GroupFailed = true;
                    Item.ItemConfirm = true;
                }
                else if(CheckDelay == false){
                    StartCoroutine(Delay());
                    
                }
                GroupOpen.StopGroup();
            }
        }
        if(TimeCounting == 1)
        {
            if(SecondsPickLeft >= 0 && CheckPick == false)
            {
                StartCoroutine(CountDownPick());
            }
            if(TimeDisplay.GetComponent<Text>().text == "0"){
                TimeDisplay.GetComponent<Text>().text = "Stop";
                TimeCounting = 0;
                source2.Play();
                CalConfirm.CalConfirm = true;
            }
        }
    }
    IEnumerator CountDownPick()
    {
        CheckPick = true;
        TimeDisplay.GetComponent<Text>().text = ""+ SecondsPickLeft;
        if(SecondsPickLeft>0){
            source1.Play();
        }
        yield return new WaitForSeconds(1);
        SecondsPickLeft -= 1;

        CheckPick = false;
    }

    public void SafeTiming()
    {
        SecondsGroupLeft = SecondsGroup;
        SecondsPickLeft = SecondsPick;
    }


    IEnumerator CountDownGroup()
    {
        CheckGroup = true;
        TimeDisplay.GetComponent<Text>().text = ""+ SecondsGroupLeft;
        if(SecondsGroupLeft>0){
            source1.Play();
        }
        yield return new WaitForSeconds(1);
        SecondsGroupLeft -= 1;

        CheckGroup = false;
    }

    public void TimeGroup(){
        TimeGroupConfirm = true;
    }
    IEnumerator Delay(){
        CheckDelay = true;
        TimeDisplay.GetComponent<Text>().text = "Next";
        yield return new WaitForSeconds(1);
        TimeCounting = 1;
        Item.ItemConfirm = true;
        ElementPick.StartRandom = true;
        ButtonColorR2AndR3.ColorR1R2Confirm = true;
        CheckDelay = false;
        
    }
}
