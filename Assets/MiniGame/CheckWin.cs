using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    
    public GameObject WinPanel;
    public static int Counting;

    void Start()
    {
        WinPanel.SetActive(false);
    }
    void Update()
    {
        if(Counting == 6){
            WinMiniGame();
        }
    }
    void WinMiniGame(){
        WinPanel.SetActive(true);
    }
}
