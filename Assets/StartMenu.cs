using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("SelectLevel");
        Time.timeScale = 1f;
    }

    public void TableScene()
    {
        SceneManager.LoadScene("TableToolTip");
        Time.timeScale = 1f;
    }


}
