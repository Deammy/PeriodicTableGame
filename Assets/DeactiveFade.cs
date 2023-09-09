using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveFade : MonoBehaviour
{

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Start()
    {   
        Time.timeScale = 1f;
        StartCoroutine(DeFade()); 
    }

    IEnumerator DeFade()
    {   
        yield return new WaitForSeconds(1);
        
        pauseMenuUI.SetActive(false);
    }
}

   

