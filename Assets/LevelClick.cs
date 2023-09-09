using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelClick : MonoBehaviour
{
    public List<LevelList> LevelList;
    public Text[] LevelName;
    public Button[] LevelButton;
    public Color ColorLock;
    public Color ColorOpen;

    // Start is called before the first frame update
    void Start()
    {
        LevelNameSet();
        UnlockLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UnlockLevel(){
        int CurrentLevel = PlayerPrefs.GetInt("CurrentLevel",0);
        for(int i = 0 ; i < LevelButton.Length ; i++){
            if(i > CurrentLevel){
                LevelButton[i].gameObject.GetComponent<Image>().color = ColorLock;
                LevelButton[i].enabled = false;
            }
            if(i <= CurrentLevel){
                LevelButton[i].gameObject.GetComponent<Image>().color = ColorOpen;
                LevelButton[i].enabled = true;
            }
        }
    }
    void LevelNameSet(){
        for(int i = 0 ; i < LevelName.Length ; i++){
            LevelName[i].GetComponent<Text>().text = LevelList[i].LevelName;
        }
    }
    public void ClickLevel(int Level){
        SceneManager.LoadScene(LevelList[Level - 1].LevelName);
    }
    public void ResetCurrentLevel(){
        PlayerPrefs.SetInt("CurrentLevel",0);
        StartCoroutine(ResetLevel());
        

    }

    IEnumerator ResetLevel()
    {   
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene("SelectLevel");
        
    }

    
}
