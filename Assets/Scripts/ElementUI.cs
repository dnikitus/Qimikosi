using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElementUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textElement;

    [SerializeField]
    private TMP_InputField textIndex;

    private int Atoms;

    private void Start()
    {
        textElement.text = PeriodicTable.SelectedElement.Label;
        textIndex.text = "";
        Atoms = 1;
    }

    public void OnSubmitElement()
    {
        PeriodicTable.SelectedElement.Atoms = Atoms;
        BalancedReactionUI.Elements[BalancedReactionUI.SelectedReactant].Add(PeriodicTable.SelectedElement);
        SceneManager.UnloadSceneAsync("Element");
    }

    public void OnCancelElement()
    {
        PeriodicTable.SelectedElement = null;        
        SceneManager.UnloadSceneAsync("Element");
    }

    public void IncreaseCount()
    {
        if (Atoms < 9)
            Atoms++;

        textElement.text = PeriodicTable.SelectedElement.Label + Atoms.ToString();       
    }

    public void DecreaseCount()
    {
        if (Atoms > 1)
            Atoms--;

        textElement.text = PeriodicTable.SelectedElement.Label;
        if (Atoms > 1)
            textElement.text += Atoms.ToString();
    }
}
