using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public bool AtkAnim = false;
    public bool SlimeHitten = false;
    public bool HittenAnim = false ;
    public bool NoHit = false;

    
    
    private Shake shake;
    private RipplePostProcessor camRipple;
    public ParticleSystem effect;


    public GameObject theNPC;
    public GameObject[] Monsters;

    //

    public AudioSource[] SoundFX;

    public GameObject Blood;
    public GameObject ElementPick;
    public int BossBlood;
    public int DMR;
    public GameObject TimeDisplay;
    public GameObject DamageDisplay;
    public GameObject ItemPanel;
    public bool CalConfirm = false;
    public MoveLeft Move;
    public GameObject ExtraDamage;
    public HealthBar healthBar;
    public LevelNow LevelNow;
    public Reset ResetConfirm;
    public ElementPick StartConfirm;
    public GameObject WinMenuUI;
    public Text[] NuclearSymbol;
    public GameObject NuclearPanel;
    public GameObject NuclearCanvasPanel;
    public Color FalseColor;
    public SkillItem Skill;
    public GameObject[] SkillResultPanel;
    public Text ItemDamage;
    public Text Heal;
    public Text Block;
    public CountDownTiming CountDownTiming;
    
    
    void Start()
    {
        Blood.GetComponent<Text>().text = "" + BossBlood;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        
    }

    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Q))
        {
            WinGame(LevelNow.LevelCurrent);
        }
        if(CalConfirm == true)
        {
            
            StartCoroutine(CalculateDamage());
        }

    }

    // Update is called once per frame
    public IEnumerator CalculateDamage()
    {
        CalConfirm = false;
        int S1 = ElementPick.GetComponent<ElementPick>().S1;
        int S2 = ElementPick.GetComponent<ElementPick>().S2;
        int S3 = ElementPick.GetComponent<ElementPick>().S3;
        if(StartConfirm.GroupCheck == true){
            DMR = 0;
            DMR = DMR + ElementPick.GetComponent<ElementPick>().GroupDMR;
            
            if (S1 == S2 && S1 == S3 && ElementPick.GetComponent<ElementPick>().Ans1 == true && ElementPick.GetComponent<ElementPick>().Ans2 == true ){
                Skill.AllSkill(1);
                DMR = DMR + Random.Range(18,22);
                if(Skill.FlameConfirm == true){
                    AtkAnim = false ;
                    SlimeHitten = false; 
                  

                }else{

                    AtkAnim = true;
                    SlimeHitten = true;

                }
            }else if((S1 == S3 && ElementPick.GetComponent<ElementPick>().Ans2 == true) || (S1 == S2 && ElementPick.GetComponent<ElementPick>().Ans1 == true)){
                Skill.AllSkill(2);
                DMR = DMR + Random.Range(8,12);
                if(Skill.FlameConfirm == true){
                    AtkAnim = false;
                    SlimeHitten = false;
                }else{
                    AtkAnim = true;
                    SlimeHitten = true ;
                }
                
                
            }
            
            
        }
        else{
            
            Skill.AllSkill(2);
            DMR = 0;
            AtkAnim = false;
            NoHit = true;

        }

        Answer();
        ElementPick.GetComponent<ElementPick>().Ans1 = false;
        ElementPick.GetComponent<ElementPick>().Ans2 = false;
        yield return new WaitForSeconds(1);
        NuclearPanel.SetActive(true);
        ScoreCollect.Turn += 1;
       
        SlimeHitten = false ;
        AtkAnim = false;
        DamageDisplay.GetComponent<Text>().text = "" + DMR;
        DamageDisplay.GetComponent<Text>().enabled = true;
        ItemDamageEnabled();
        NoHit = false;
        BossBlood = BossBlood - DMR - Skill.ItemDamage - Skill.Burn;

        yield return new WaitForSeconds(1);
        StartCoroutine(TakeDamage());
        Blood.GetComponent<Text>().text = "" + BossBlood;
        yield return new WaitForSeconds(1);
        if(BossBlood != 0){
            Move.MoveLefting();
        }
        yield return new WaitForSeconds(1);
        ResetConfirm.ResetConfirm = true;
        StartConfirm.StartConfirm = true;
        StartConfirm.GroupCheck = false;

        //ExtraDamage.GetComponent<Item>().Confirm = false;
    }

    IEnumerator TakeDamage()
    {   
        healthBar.SetHealth(BossBlood);
        
        if(BossBlood <= 0)
        {   
            BossBlood = 0;
            Destroy(Monsters[0]);
            
            shake.CamShake();
            effect.Play();
            //Instantiate(effect, transform.position, Quaternion.identity);
            
            camRipple.RippleEffect();
            yield return new WaitForSeconds(1);
            WinGame(LevelNow.LevelCurrent);
        }
        
    }

    public void WinGame(int LevelNow){

        StartCoroutine(ActiveWin()); 
        if(LevelNow > PlayerPrefs.GetInt("CurrentLevel")){
            PlayerPrefs.SetInt("CurrentLevel",LevelNow);
        }
    }

    public void NextLevelButton(){

        if(PlayerPrefs.GetInt("CurrentLevel") == 5){
            SceneManager.LoadScene("Quit");
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    IEnumerator ActiveWin()
    { 

        yield return new WaitForSeconds(1);
        ScoreCollect.ScoreMass = 0;
        ScoreCollect.ScoreAtom = 0;
        ScoreCollect.ScoreGroup = 0;
        ScoreCollect.Turn = 0;
        WinMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    void Answer(){
        if(CountDownTiming.GroupFailed == true){
            NuclearCanvasPanel.SetActive(false);
            CountDownTiming.GroupFailed = false;
        }
        NuclearSymbol[0].text = StartConfirm.Elements[StartConfirm.Choose].Elements;

        NuclearSymbol[1].text = StartConfirm.Elements[StartConfirm.Choose].MassNumber;
        if(ElementPick.GetComponent<ElementPick>().S2 != StartConfirm.Choose || ElementPick.GetComponent<ElementPick>().Ans1 == false)
        {
            NuclearSymbol[1].color = FalseColor;
        }
        else
        {
            ScoreCollect.ScoreMass +=1000;
        }

        NuclearSymbol[2].text = StartConfirm.Elements[StartConfirm.Choose].AtomNumber;
        if(ElementPick.GetComponent<ElementPick>().S3 != StartConfirm.Choose || ElementPick.GetComponent<ElementPick>().Ans2 == false)
        {
            NuclearSymbol[2].color = FalseColor;
        }
        else
        {
            ScoreCollect.ScoreAtom +=1000;
        }

        NuclearSymbol[3].text = StartConfirm.Elements[StartConfirm.Choose].Group;
        if(ElementPick.GetComponent<ElementPick>().S4 != StartConfirm.Elements[StartConfirm.Choose].Group || ElementPick.GetComponent<ElementPick>().GroupCheck == false)
        {
            NuclearSymbol[3].color = FalseColor;
        }
        else
        {
            ScoreCollect.ScoreGroup +=1000;
        }
    }

    void ItemDamageEnabled(){
        //////////////////////
        int ItemDamageAll = Skill.ItemDamage + Skill.Burn;
        ItemDamage.text = "" + ItemDamageAll;
        if(Skill.ItemDamage != 0){
            SkillResultPanel[0].SetActive(true);
        }
        /////////////////////////
        Heal.text = "" + Skill.Heal;
        if(Skill.Heal != 0){
            SkillResultPanel[1].SetActive(true);
        }
        
        Block.text = "" + Skill.ItemBlock;
        if(Skill.ItemBlock != 0){
            SkillResultPanel[2].SetActive(true);
        }    
    }
}
