using Mehroz;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BalancedReactionUI : MonoBehaviour
{
    [SerializeField]
    TMP_Text textElementA, textElementB, textElementC, textElementD;  

    [SerializeField]
    public static List<List<Element>> Elements;

    public static int SelectedReactant;
    public int MoleculesA, MoleculesB, MoleculesC, MoleculesD;

    private void Start()
    {
        Elements = new()
        {
            new(),
            new(),
            new(),
            new()
        };        
    }

    public void ShowPeriodicTable(int index)
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
        SelectedReactant = index;
        SceneManager.LoadScene("PeriodicTable", LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene current)
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
        if (current != null)
        {
            if (current.name == "PeriodicTable")
            {
                SceneManager.sceneUnloaded += OnSceneUnloaded;
                SceneManager.LoadScene("Element", LoadSceneMode.Additive);
            }
            else if (current.name == "Element")
            {
                UpdateReactants();                              
            }
        }
    }

    public void ResetReaction()
    {
        Elements = new()
        {
            new(),
            new(),
            new(),
            new()
        };
        MoleculesD = 0;
        MoleculesC = 0;
        MoleculesB = 0;
        MoleculesA = 0;
        UpdateReactants();
    }

    public void IncreaseCount(TMP_Text textElement)
    {
        if (textElement.text == "?")
            return;

        if (!int.TryParse(textElement.text[0].ToString(), out int n))
            n = 1;
        n++;

        while (char.IsDigit(textElement.text[0]))
            textElement.text = textElement.text.Remove(0, 1);

        textElement.text = n.ToString() + textElement.text;
    }

    public void DecreaseCount(TMP_Text textElement)
    {
        if (textElement.text == "?")
            return;

        if (!int.TryParse(textElement.text[0].ToString(), out int n))
            n = 1;
        n--;

        while (char.IsDigit(textElement.text[0]))
            textElement.text = textElement.text.Remove(0, 1);

        if (n > 1)
            textElement.text = n.ToString() + textElement.text;
    }

    private void UpdateReactants()
    {
        textElementA.text = Elements[0].Count > 0 ? "" : "?";
        textElementB.text = Elements[1].Count > 0 ? "" : "?";
        textElementC.text = Elements[2].Count > 0 ? "" : "?";
        textElementD.text = Elements[3].Count > 0 ? "" : "?";

        if (MoleculesA > 1)
            textElementA.text += "<color=#D05685>" + MoleculesA.ToString() + "</color>";
        foreach (Element e in Elements[0])
        {
            textElementA.text += e.Label;
            if (e.Atoms > 1)
                textElementA.text += e.Atoms.ToString();
        }

        if (MoleculesB > 1)
            textElementB.text += "<color=#D05685> " + MoleculesB.ToString() + "</color>";
        foreach (Element e in Elements[1])
        {
            textElementB.text += e.Label;
            if (e.Atoms > 1)
                textElementB.text += e.Atoms.ToString();
        }
                
        if (MoleculesC > 1)
            textElementC.text += "<color=#D05685>" + MoleculesC.ToString() + "</color>";
        foreach (Element e in Elements[2])
        {
            textElementC.text += e.Label;
            if (e.Atoms > 1)
                textElementC.text += e.Atoms.ToString();
        }

        if (MoleculesD > 1)
            textElementD.text += "<color=#D05685>" + MoleculesD.ToString() + "</color>";
        foreach (Element e in Elements[3])
        {
            textElementD.text += e.Label;
            if (e.Atoms > 1)
                textElementD.text += e.Atoms.ToString();
        }
    }

    public void OnBalanceReaction()
    {
        MoleculesA = MoleculesB = MoleculesC = MoleculesD = 1;

        Dictionary<string, int> reactants = new();
        foreach (var e in Elements[0])
            AddOrUpdate(reactants, e.Label, MoleculesA * e.Atoms);
        foreach (var e in Elements[1])
            AddOrUpdate(reactants, e.Label, MoleculesB * e.Atoms);
        foreach (var e in Elements[2])
            AddOrUpdate(reactants, e.Label, MoleculesC * e.Atoms);
        foreach (var e in Elements[3])
            AddOrUpdate(reactants, e.Label, MoleculesD * e.Atoms);

        int nrows = reactants.Keys.Count;
        int ncols = 4;

        List<string> names = new();
        foreach (KeyValuePair<string, int> e in reactants)
            names.Add(e.Key);

        double[,] A = new double[nrows, ncols];
        for (int i = 0; i < names.Count; i++)
        {
            for (int j = 0; j < Elements.Count; j++)
            {
                for (int k = 0; k < Elements[j].Count; k++)
                {
                    if (Elements[j][k].Label == names[i])
                    {
                        A[i, j] = Elements[j][k].Atoms;
                        if (j > 1)
                            A[i, j] = -A[i, j];
                    }
                }
            }
        }  

        Matrix mat = new(A);
        mat = mat.ReducedEchelonForm();

        int t = 1;
        for (int i=0; i<nrows; i++)
            t = LCM(t, (int)mat[i, 3].Denominator);

        MoleculesA = (int)(-mat[0, 3].ToDouble() * t);
        MoleculesB = (int)(-mat[1, 3].ToDouble() * t);
        MoleculesC = (int)(-mat[2, 3].ToDouble() * t);
        MoleculesD = t;

        UpdateReactants();
    }

    private int LCM(int a, int b)
    {
        int num1, num2;
        if (a > b)
        {
            num1 = a;
            num2 = b;
        }
        else
        {
            num1 = b;
            num2 = a;
        }
        for (int i=1; i<num2; i++)
        {
            int mult = num1 * i;
            if (mult % num2 == 0)
                return mult;
        }
        return num1 * num2;
    }

    private void AddOrUpdate(Dictionary<string, int> dict, string key, int value)
    {
        int val;
        if (dict.TryGetValue(key, out val))
            dict[key] = val + value;
        else
            dict.Add(key, value);
    }
}
