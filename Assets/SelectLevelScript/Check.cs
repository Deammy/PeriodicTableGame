using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    // Start is called before the first frame update
    public int PlayerPref;
    // Update is called once per frame
    void Update()
    {
        PlayerPref = PlayerPrefs.GetInt("CurrentLevel",0);
    }
}
