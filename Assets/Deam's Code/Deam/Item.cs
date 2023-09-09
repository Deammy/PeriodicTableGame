using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Button[] ItemButton;
    public GameObject ItemPanel;
    public List<ItemList> ItemList;
    public int ExtraDamage;

    public int ExtraMove;
    public ColorForEvery Color;
    public bool ItemConfirm = false;
    public ElementPick RandomConfirm;
    public ButtonColorR2AndR3 ColorR1R2Confirm;
    public bool ItemOffOn = false;
    
    public void Update()
    {
        if(ItemConfirm == true && ItemOffOn)
        {
            StartCoroutine(OffItemPanel());
        }
    }
    public void OpenItemPanel()
    {
        if(ItemOffOn){
            ItemPanel.SetActive(true);
        }
    }
    public void ItemClose(int ButtonNumber)
    {
        for(int i = 0 ; i < ItemButton.Length ; i++)
        {
            if(ItemButton[i].gameObject.GetComponent<Image>().color != Color.ActiveColor){
                ItemButton[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            }
        }
        ItemButton[ButtonNumber].gameObject.GetComponent<Image>().color = Color.InactiveColor;
    }
    IEnumerator OffItemPanel()
    {
        for(int i = 0 ; i < ItemButton.Length ; i++)
        {
            ItemButton[i].enabled = false;
        }
        yield return new WaitForSeconds(1);
        ItemPanel.SetActive(false);
        ItemConfirm = false;
        for(int i = 0 ; i < ItemButton.Length ; i++)
        {
            if(i != 0){
                if(ItemButton[i].gameObject.GetComponent<Image>().color != Color.InactiveColor && ItemButton[i].gameObject.GetComponent<Image>().color != Color.ActiveColor)
                {
                    ItemButton[i].enabled = true;
                    ItemButton[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
                }
                else{
                    ItemButton[i].gameObject.GetComponent<Image>().color = Color.ActiveColor;
                }
            }
            else{
                ItemButton[i].enabled = true;
                ItemButton[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            }
        }
    }
}
