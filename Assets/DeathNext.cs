using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathNext : MonoBehaviour
{

    public void NextToQuit()
    {
        SceneManager.LoadScene("menu");
    }

    public void BackToSelectLevel()
    {
        SceneManager.LoadScene("SelectLevel");
    }


}