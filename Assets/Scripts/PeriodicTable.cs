using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class PeriodicTable : MonoBehaviour
{
    [SerializeField]
    GameObject ElementPrefab;

    [SerializeField]
    GameObject EmptyPrefab;

    [SerializeField] List<Color> Colors;
    [SerializeField] List<Color> TextColors;

    public Dictionary<string, Element> Elements;
    
    public static Element SelectedElement;

    void Start()
    {
        SelectedElement = null;
        Elements = new();

        foreach (Transform child in transform)
        {
            child.transform.SetParent(null);
            Destroy(child.gameObject);
        }

        AddElement("1", "H", Colors[5], TextColors[5]);
        
        AddElement("2", "He", Colors[6], TextColors[6]);
        
        AddElement("3", "Li", Colors[0], TextColors[0]);
        
        AddElement("4", "Be", Colors[1], TextColors[1]);
        
        AddElement("5", "B", Colors[4], TextColors[4]);

        AddElement("6", "C", Colors[5], TextColors[5]);
        AddElement("7", "N", Colors[5], TextColors[5]);
        AddElement("8", "O", Colors[5], TextColors[5]);
        AddElement("9", "F", Colors[5], TextColors[5]);

        AddElement("10", "Ne", Colors[6], TextColors[6]);

        AddElement("11", "Na", Colors[0], TextColors[0]);

        AddElement("12", "Mg", Colors[1], TextColors[1]);

        AddElement("13", "Al", Colors[3], TextColors[3]);

        AddElement("14", "Si", Colors[4], TextColors[4]);

        AddElement("15", "P", Colors[5], TextColors[5]);
        AddElement("16", "S", Colors[5], TextColors[5]);
        AddElement("17", "Cl", Colors[5], TextColors[5]);

        AddElement("18", "Ar", Colors[6], TextColors[6]);

        AddElement("19", "K", Colors[0], TextColors[0]);

        AddElement("20", "Ca", Colors[1], TextColors[1]);

        AddElement("21", "Sc", Colors[2], TextColors[2]);
        AddElement("22", "Ti", Colors[2], TextColors[2]);
        AddElement("23", "V", Colors[2], TextColors[2]);
        AddElement("24", "Cr", Colors[2], TextColors[2]);
        AddElement("25", "Mn", Colors[2], TextColors[2]);
        AddElement("26", "Fe", Colors[2], TextColors[2]);
        AddElement("27", "Co", Colors[2], TextColors[2]);
        AddElement("28", "Ni", Colors[2], TextColors[2]);
        AddElement("29", "Cu", Colors[2], TextColors[2]);
        AddElement("30", "Zn", Colors[2], TextColors[2]);

        AddElement("31", "Ga", Colors[3], TextColors[3]);

        AddElement("32", "Ge", Colors[4], TextColors[4]);
        AddElement("33", "As", Colors[4], TextColors[4]);

        AddElement("34", "Se", Colors[5], TextColors[5]);
        AddElement("35", "Br", Colors[5], TextColors[5]);

        AddElement("36", "Kr", Colors[6], TextColors[6]);

        AddElement("37", "Rb", Colors[0], TextColors[0]);

        AddElement("38", "Sr", Colors[1], TextColors[1]);

        AddElement("39", "Y", Colors[2], TextColors[2]);
        AddElement("40", "Zr", Colors[2], TextColors[2]);
        AddElement("41", "Nb", Colors[2], TextColors[2]);
        AddElement("42", "Mo", Colors[2], TextColors[2]);
        AddElement("43", "Tc", Colors[2], TextColors[2]);
        AddElement("44", "Ru", Colors[2], TextColors[2]);
        AddElement("45", "Rh", Colors[2], TextColors[2]);
        AddElement("46", "Pd", Colors[2], TextColors[2]);
        AddElement("47", "Ag", Colors[2], TextColors[2]);
        AddElement("48", "Cd", Colors[2], TextColors[2]);

        AddElement("49", "In", Colors[3], TextColors[3]);
        AddElement("50", "Sn", Colors[3], TextColors[3]);

        AddElement("51", "Sb", Colors[4], TextColors[4]);
        AddElement("52", "Te", Colors[4], TextColors[4]);

        AddElement("53", "I", Colors[5], TextColors[5]);

        AddElement("54", "Xe", Colors[6], TextColors[6]);

        AddElement("55", "Cs", Colors[0], TextColors[0]);

        AddElement("56", "Ba", Colors[1], TextColors[1]);

        AddElement("57", "La", Colors[7], TextColors[7]);
        AddElement("58", "Ce", Colors[7], TextColors[7]);
        AddElement("59", "Pr", Colors[7], TextColors[7]);
        AddElement("60", "Nd", Colors[7], TextColors[7]);
        AddElement("60", "Pm", Colors[7], TextColors[7]);
        AddElement("61", "Sm", Colors[7], TextColors[7]);
        AddElement("62", "Eu", Colors[7], TextColors[7]);
        AddElement("63", "Gd", Colors[7], TextColors[7]);
        AddElement("64", "Tb", Colors[7], TextColors[7]);
        AddElement("65", "Dy", Colors[7], TextColors[7]);
        AddElement("66", "Ho", Colors[7], TextColors[7]);
        AddElement("67", "Er", Colors[7], TextColors[7]);
        AddElement("68", "Tm", Colors[7], TextColors[7]);
        AddElement("69", "Yb", Colors[7], TextColors[7]);
        AddElement("70", "Lu", Colors[7], TextColors[7]);

        AddElement("72", "Hf", Colors[2], TextColors[2]);
        AddElement("73", "Ta", Colors[2], TextColors[2]);
        AddElement("74", "W", Colors[2], TextColors[2]);
        AddElement("75", "Re", Colors[2], TextColors[2]);
        AddElement("76", "Os", Colors[2], TextColors[2]);
        AddElement("77", "Ir", Colors[2], TextColors[2]);
        AddElement("78", "Pt", Colors[2], TextColors[2]);
        AddElement("79", "Au", Colors[2], TextColors[2]);
        AddElement("80", "Hg", Colors[2], TextColors[2]);

        AddElement("81", "Tl", Colors[3], TextColors[3]);
        AddElement("82", "Pb", Colors[3], TextColors[3]);
        AddElement("83", "Bi", Colors[3], TextColors[3]);
        AddElement("84", "Po", Colors[3], TextColors[3]);
        AddElement("85", "At", Colors[3], TextColors[3]);

        AddElement("86", "Rn", Colors[6], TextColors[6]);

        AddElement("87", "Fr", Colors[0], TextColors[0]);

        AddElement("88", "Ra", Colors[1], TextColors[1]);

        AddElement("89", "Ac", Colors[8], TextColors[8]);
        AddElement("90", "Th", Colors[8], TextColors[8]);
        AddElement("91", "Pa", Colors[8], TextColors[8]);
        AddElement("92", "U", Colors[8], TextColors[8]);
        AddElement("93", "Np", Colors[8], TextColors[8]);
        AddElement("94", "Pu", Colors[8], TextColors[8]);
        AddElement("95", "Am", Colors[8], TextColors[8]);
        AddElement("96", "Cm", Colors[8], TextColors[8]);
        AddElement("97", "Bk", Colors[8], TextColors[8]);
        AddElement("98", "Cf", Colors[8], TextColors[8]);
        AddElement("99", "Es", Colors[8], TextColors[8]);
        AddElement("100", "Fm", Colors[8], TextColors[8]);
        AddElement("101", "Md", Colors[8], TextColors[8]);
        AddElement("102", "No", Colors[8], TextColors[8]);
        AddElement("103", "Lr", Colors[8], TextColors[8]);

        AddElement("104", "Rf", Colors[2], TextColors[2]);
        AddElement("105", "Db", Colors[2], TextColors[2]);
        AddElement("106", "Sg", Colors[2], TextColors[2]);
        AddElement("107", "Bh", Colors[2], TextColors[2]);
        AddElement("108", "Hs", Colors[2], TextColors[2]);

        AddElement("109", "Mt", Colors[9], TextColors[9]);
        AddElement("110", "Ds", Colors[9], TextColors[9]);
        AddElement("111", "Rg", Colors[9], TextColors[9]);
        AddElement("112", "Cn", Colors[9], TextColors[9]);
        AddElement("113", "Nh", Colors[9], TextColors[9]);
        AddElement("114", "Fl", Colors[9], TextColors[9]);
        AddElement("115", "Mc", Colors[9], TextColors[9]);
        AddElement("116", "Lv", Colors[9], TextColors[9]);
        AddElement("117", "Ts", Colors[9], TextColors[9]);
        AddElement("118", "Og", Colors[9], TextColors[9]);
    }

    private void AddEmptyElement()
    {
        Instantiate(EmptyPrefab, transform);
    }

    private void AddElement(string number, string label, Color color, Color textColor)
    {
        Element element;
        GameObject spawn;
        spawn = Instantiate(ElementPrefab, transform);
        element = spawn.GetComponent<Element>();
        element.Init(number, label, color, textColor);
        Elements.Add(label, element);
    }
}
