using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorR1 : MonoBehaviour
{
    public Button[] R1Role;
    public ColorForEvery Color;
    // Start is called before the first frame update
    public void Start(){
        for(int i = 0 ; i < R1Role.Length ; i++)
        {
            R1Role[i].enabled = true;
            R1Role[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
        }
    }
    public void R1Click(int C1)
    {
        for(int i = 0 ; i < R1Role.Length ; i++)
        {
            if(i == C1)
            {
                R1Role[i].enabled = false;
                R1Role[i].gameObject.GetComponent<Image>().color = Color.ActiveColor;
            }
            else
            {
                R1Role[i].enabled = false;
                R1Role[i].gameObject.GetComponent<Image>().color = Color.InactiveColor;
            }
        }

    }
}
