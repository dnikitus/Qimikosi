using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassesUI : MonoBehaviour
{
    public void ZogadiInfo()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SceneManager.LoadScene("PeriodicTable", LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene current)
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;

        if (current != null)
        {
            
        }
    }

    public void Class8()
    {
        SceneManager.LoadScene(2);
    }
    public void Class9()
    {
        SceneManager.LoadScene(3);
    }
    public void Class10()
    {
        SceneManager.LoadScene(4);
    }
    public void Class11()
    {
        SceneManager.LoadScene(5);
    }
    public void Back2()
    {
        SceneManager.LoadScene(0);
    }
}
