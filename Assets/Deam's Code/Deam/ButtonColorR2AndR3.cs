using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorR2AndR3 : MonoBehaviour
{
    public Button[] R2Role;
    public Button[] R3Role;
    public ColorForEvery Color;
    public bool ColorR1R2Confirm = false;
    public Text TimeText;
    public ElementPick Ans;
    int K1;
    int K2;
    public void Update()
    {
        if(ColorR1R2Confirm == true)
        {
            for(int i = 0 ; i < R2Role.Length ; i++)
            {
            R2Role[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            R2Role[i].enabled = true;
            //////////////////////////////////
            R3Role[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            R3Role[i].enabled = true;
            }
            ColorR1R2Confirm = false;
        }
        if(TimeText.text == "Stop")
        {
            LockButton();
        }
    }
    public void ClickR2(int number)
    {
        for(int i = 0 ; i < R2Role.Length ; i++)
        {
            if(number == i)
            {
                R2Role[i].gameObject.GetComponent<Image>().color = Color.ActiveColor;
            }
            else
            {
                R2Role[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            }
        }
    }
    public void ClickR3(int number)
    {
        for(int i = 0 ; i < R3Role.Length ; i++)
        {
            if(number == i)
            {
                R3Role[i].gameObject.GetComponent<Image>().color = Color.ActiveColor;
            }
            else
            {
                R3Role[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            }
        }
    }
    public void GetNumber1(int number)
    {
        K1 = number;
    }
    public void GetNumber2(int number)
    {
        K2 = number;
    }
    public void LockButton()
    {
        for(int i = 0 ; i < R3Role.Length ; i++)
        {
            if(i == K1 && Ans.ChangeButtonColor1 == true)
            {
                R2Role[i].enabled = false;
            }
            else
            {
                R2Role[i].gameObject.GetComponent<Image>().color = Color.InactiveColor;
                R2Role[i].enabled = false;
            }
        }
        for(int i = 0 ; i < R3Role.Length ; i++)
        {
            if(i == K2 && Ans.ChangeButtonColor2 == true)
            {
                R3Role[i].enabled = false;
            }
            else
            {
                R3Role[i].gameObject.GetComponent<Image>().color = Color.InactiveColor;
                R3Role[i].enabled = false;
            }
        }
    }
}
