using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Element : MonoBehaviour
{
    [SerializeField]
    TMP_Text textLabel;
    
    [SerializeField]
    TMP_Text textNumber;

    public int Atoms;

    public void Init(string number, string label, Color color, Color textColor)
    {
        Atoms = 1;
        Color = color;
        TextColor = textColor;
        Label = label;
        Number = number;
    }

    public Color Color
    {
        get => GetComponent<Image>().color;
        set
        {
            GetComponent<Image>().color = value;
            textLabel.color = value;
        }
    }

    public Color TextColor
    {
        get => textLabel.color;
        set
        {
            textLabel.color = value;
            textNumber.color = value;
        }
    }

    public string Number
    {
        get => textNumber.text;
        set => textNumber.text = value;
    }

    public string Label
    {
        get => textLabel.text;
        set => textLabel.text = value;
    }

    public void OnSelectElement()
    {
        PeriodicTable.SelectedElement = this;
        SceneManager.UnloadSceneAsync("PeriodicTable");        
    }
}
