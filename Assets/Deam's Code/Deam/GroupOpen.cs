using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupOpen : MonoBehaviour
{
    public Color ActiveColor;
    public Color ClickColor;
    public Button[] GroupButton; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenGroup()
    {
        for(int i = 0 ; i < GroupButton.Length ; i++)
        {
            GroupButton[i].enabled = true;
            GroupButton[i].gameObject.GetComponent<Image>().color = ActiveColor;
        }
    }
    public void ClickGroup(int Click)
    {
        for(int i = 0 ; i < GroupButton.Length ; i++)
        {
            if(Click-1 == i)
            {
                GroupButton[i].gameObject.GetComponent<Image>().color = ClickColor;
            }
            else
            {
                GroupButton[i].gameObject.GetComponent<Image>().color = ActiveColor;
            }
        }
    }
    public void StopGroup(){
        for(int i = 0 ; i < GroupButton.Length ; i++){
            GroupButton[i].enabled = false;
        }
    }
}
