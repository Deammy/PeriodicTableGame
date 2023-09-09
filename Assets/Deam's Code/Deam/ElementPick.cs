using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class ElementPick : MonoBehaviour
{
    public List<Element> Elements;
    public int E1;
    
    public int E2;
    
    public int E3;
    
    public int M1;
    
    public int M2;
    
    public int M3;
    
    public int A1;
    
    public int A2;
    
    public int A3;
    public int S1;
    public int S2;
    public int S3;
    public string S4;
    //////////////
    public Text[] R1Text;
    public Text[] R2Text;
    public Text[] R3Text;

    public bool StartConfirm = false;
    public bool Ans1 = false;
    public bool Ans2 = false;
    public bool ChangeButtonColor1 = false;
    public bool ChangeButtonColor2 = false;
    public bool GroupCheck = false;
    public bool GroupClick = false;
    public int GroupDMR;

    public int Choose;
    int[] EList = new int[3];
    int[] MList = new int[3];
    int[] AList = new int[3];
    public bool StartRandom = false;
    public void Start()
    {
        GenerateElementRole();
        ElementAll.Element = Elements;
    }

    ///////Generate Zone//////////
    private void Update()
    {
        if(StartConfirm == true){
            GenerateElementRole();
            StartConfirm = false;
        }
        if(StartRandom == true)
        {
            GenerateMassNumberRole();
            GenerateAtomNumberRole();
            StartRandom = false;
        }
    }
    public void ChooseElement(int number)
    {
        Choose = EList[number];
        S1 = EList[number];
    }
    void GenerateElementRole()
    {
        E1 = Random.Range(0,Elements.Count);
        E2 = Random.Range(0,Elements.Count);
        E3 = Random.Range(0,Elements.Count);
        while (E1 == E2 || E1 == E3 || E2 == E3)
        {
            E2 = Random.Range(0,Elements.Count);
            E3 = Random.Range(0,Elements.Count); 
        }
        EList[0] = E1;
        EList[1] = E2;
        EList[2] = E3;
        for(int i = 0 ; i < R1Text.Length ; i++)
        {
            ///////////////Change Button Express//////////////
            R1Text[i].text = Elements[EList[i]].Elements;
        }
    }
    void GenerateMassNumberRole()
    {
        M1 = Choose;
        M2 = Random.Range(0,Elements.Count);
        M3 = Random.Range(0,Elements.Count);
        while (M1 == M2 || M1 == M3 || M2 == M3)
        {
            M2 = Random.Range(0,Elements.Count);
            M3 = Random.Range(0,Elements.Count); 
        }
        ShuffleMass();
        MList[0] = M1;
        MList[1] = M2;
        MList[2] = M3;
        for(int i = 0 ; i < R1Text.Length ; i++)
        {
            ///////////////Change Button Express//////////////
            R2Text[i].text = Elements[MList[i]].MassNumber;
        }
    }
    void GenerateAtomNumberRole()
    {
        A1 = Choose;
        A2 = Random.Range(0,Elements.Count);
        A3 = Random.Range(0,Elements.Count);
        while (A1 == A2 || A1 == A3 || A2 == A3)
        {
            A2 = Random.Range(0,Elements.Count);
            A3 = Random.Range(0,Elements.Count); 
        }
        ShuffleAtom();
        AList[0] = A1;
        AList[1] = A2;
        AList[2] = A3;
        for(int i = 0 ; i < R1Text.Length ; i++)
        {
            ///////////////Change Button Express//////////////
            R3Text[i].text = Elements[AList[i]].AtomNumber;
        }
    }

    ////Click Zone/////////
    public void R2Click(int number)
    {
        S2 = MList[number];
        Ans1 = true;
        ChangeButtonColor1 = true;
    }
    public void R3Click(int number)
    {
        S3 = AList[number];
        Ans2 = true;
        ChangeButtonColor2 = true;
    }
    public void ShuffleMass()  
    {  
        int[] MShuffleList = new int[3];
        MShuffleList[0] = M1;
        MShuffleList[1] = M2;
        MShuffleList[2] = M3;
        int R1 = Random.Range(0,MShuffleList.Length);
        int R2 = Random.Range(0,MShuffleList.Length);
        int R3 = Random.Range(0,MShuffleList.Length);
        while (R1 == R2 || R1 == R3 || R2 == R3)
        {
            R2 = Random.Range(0,MShuffleList.Length);
            R3 = Random.Range(0,MShuffleList.Length);
        }
        M1 = MShuffleList[R1];
        M2 = MShuffleList[R2];
        M3 = MShuffleList[R3];
    }
    public void ShuffleAtom()  
    {
        int[] AShuffleList = new int[3];
        AShuffleList[0] = A1;
        AShuffleList[1] = A2;
        AShuffleList[2] = A3;
        int R1 = Random.Range(0,AShuffleList.Length);
        int R2 = Random.Range(0,AShuffleList.Length);
        int R3 = Random.Range(0,AShuffleList.Length);
        while (R1 == R2 || R1 == R3 || R2 == R3)
        {
            R2 = Random.Range(0,AShuffleList.Length);
            R3 = Random.Range(0,AShuffleList.Length);
        }
        A1 = AShuffleList[R1];
        A2 = AShuffleList[R2];
        A3 = AShuffleList[R3];
    }
    public void GroupPick(string group)
    {
        GroupClick = true;
        if(group == Elements[S1].Group)
        {
            S4 = group;
            GroupDMR = 10;
            GroupCheck = true;
        }
        else{
            GroupCheck = false;
        }
    }
}
