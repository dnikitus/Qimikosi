using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void OpenHelp()
    {
        SceneManager.LoadScene(10);
    }

    public void StartClass()
    {
        SceneManager.LoadScene(1);
    }


}
