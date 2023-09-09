using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public void GoToStart()
    {
        SceneManager.LoadScene("menu");
    }


}
