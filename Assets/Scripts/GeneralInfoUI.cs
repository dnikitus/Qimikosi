using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralInfoUI : MonoBehaviour
{
    private void Update()
    {
        if (PeriodicTable.SelectedElement != null)
        {
            //Debug.Log(PeriodicTable.SelectedElement.Label);    
            if(PeriodicTable.SelectedElement.Label == "H")
            {
                SceneManager.LoadScene(11);
            }
        }

        if (PeriodicTable.SelectedElement != null)
        {
            //Debug.Log(PeriodicTable.SelectedElement.Label);    
            if (PeriodicTable.SelectedElement.Label == "He")
            {
                SceneManager.LoadScene(12);
            }
        }

        if (PeriodicTable.SelectedElement != null)
        {
            //Debug.Log(PeriodicTable.SelectedElement.Label);    
            if (PeriodicTable.SelectedElement.Label == "C")
            {
                SceneManager.LoadScene(11);
            }
        }

    }

    
}
