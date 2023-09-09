using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAccuracy : MonoBehaviour
{
    public Text Score;
    public int A;
    // Start is called before the first frame update
    void Start()
    {

        A = (ScoreCollect.ScoreMass + ScoreCollect.ScoreAtom + ScoreCollect.ScoreGroup)/(3 * ScoreCollect.Turn);
        int Float = A % 10;
        int Integer = (A - Float)/10;
        

        Score.text = "" + Integer + "." + Float;

        ScoreCollect.ScoreMass = 0;
        ScoreCollect.ScoreAtom = 0;
        ScoreCollect.ScoreGroup = 0;
        ScoreCollect.Turn = 0;
    }

    // Update is called once per frame
}
