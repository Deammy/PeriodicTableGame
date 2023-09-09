using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePicBox : MonoBehaviour
{
    public List<PicElementList> Pic;
    public GameObject[] BoxObject;
    private int[] Box = {0,0,0,0,0,0};
    // Start is called before the first frame update
    void Start()
    {
        GenerateNumber();
        ChangePic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateNumber(){
        for(int i = 0 ; i < 6 ; i++){
            Box[i] = Random.Range(0,ElementAll.Element.Count-1);
        }
        for(int i = 0 ; i < 6 ; i++){
            for(int k = i+1 ; k < 6 ; k++){
                while(Box[i] == Box[k]){
                    Box[k] = Random.Range(0,ElementAll.Element.Count-1);
                }
            }
        }
    }
    void ChangePic(){
        for(int i = 0 ; i < 6 ; i++){
            BoxObject[i].GetComponent<SpriteRenderer>().sprite = Pic[Box[i]].Pic;
            BoxObject[i].GetComponent<SafeElementN>().X = Box[i];
        }
    }
}
