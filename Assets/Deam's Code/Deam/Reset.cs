using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reset : MonoBehaviour
{
    //////////////////////////////////////////////////
    public Button[] R1Button;
    public Button[] R2Button;
    public Button[] R3Button;
    public Button[] GroupButton;
    public Text[] NuclearSymbol;
    public Text[] Text;
    public Text TimeDisplay;
    public ColorForEvery Color;
    public Color TrueColor;

    public GameObject ItemPanel;
    public GameObject[] SkillResultPanel;
    public GameObject NuclearCanvasPanel;

    public ElementPick ColorButtonConfirm;
    public bool ResetConfirm = false;
    public bool ResultConfirm = false;
    public bool ItemPanelSetting = false;
    public Text Result;
    public GameObject NuclearPanel;
    public SkillItem Skill;

    void Start()
    {
        ResetColor();
        ResetGroup();
        ItemPanelOff();
        ResetText();
        ResetSkill();
    }
    
    public void Update()
    {
        if(ResetConfirm == true)
        {
            ResetColor();
            ResetGroup();
            if(ItemPanelSetting == true){
                ItemPanelOffV2();
            }
            else{
               ItemPanelOff(); 
            }
            ResetText();
            ResetTime();
            ResetSkill();
            ResetConfirm = false;
        }
    }
    
    void ResetColor()
    {

        for(int i = 0 ; i < R1Button.Length ; i++)
        {
            R1Button[i].gameObject.GetComponent<Image>().color = Color.NormalColor;
            R1Button[i].enabled = true;
            ////////////////////////////////////
            R2Button[i].enabled = false;
            R2Button[i].gameObject.GetComponent<Image>().color = Color.InactiveColor;
            ////////////////////////////////////
            R3Button[i].enabled = false;
            R3Button[i].gameObject.GetComponent<Image>().color = Color.InactiveColor;
            ////////////////////////////////////
            ColorButtonConfirm.ChangeButtonColor1 = false;
            ColorButtonConfirm.ChangeButtonColor2 = false;
        }

        for(int i = 0 ; i < NuclearSymbol.Length ; i++)
        {
            NuclearSymbol[i].color = TrueColor;
        }

    }

    void ResetGroup()
    {
        for(int i = 0 ; i < GroupButton.Length ; i++)
        {
            Color color = Color.InactiveColor;
            GroupButton[i].enabled = false;
            GroupButton[i].gameObject.GetComponent<Image>().color = color;
            ColorButtonConfirm.GroupClick = false;
        }
    }

    void ItemPanelOff()
    {
        ItemPanel.SetActive(false);
        NuclearPanel.SetActive(false);
        NuclearCanvasPanel.SetActive(true);
    }
    void ItemPanelOffV2()
    {
        NuclearPanel.SetActive(false);
        NuclearCanvasPanel.SetActive(true);
    }

    void ResetText()
    {
        for(int i = 0 ; i < Text.Length ; i++)
        {
            Text[i].text = "-";
        }
            Result.enabled = false;
    }

    void ResetTime()
    {
        TimeDisplay.text = "Next";
    }

    void ResetSkill()
    {
        Skill.ItemDamage = 0;
        Skill.Burn = 0;
        Skill.ItemBlock = 0;
        Skill.Heal = 0;
        SkillResultPanel[0].SetActive(false);
        SkillResultPanel[1].SetActive(false);
        SkillResultPanel[2].SetActive(false);
    }
}
