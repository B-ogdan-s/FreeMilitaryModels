using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TextColorConverter
{
    private const string _disableColor = "989898FF";
    private const string _enableColor = "FFFFFFFF";
    private const string _smolColor = "E2A965FF";

    private static TextColorConverter _instance;


    public static TextColorConverter Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new TextColorConverter();
            }

            return _instance;
        }
    }

    public string SetColor(string value)
    {
        string newText = "";

        bool firstSimvol = false;

        for(int i = 0; i < value.Length; i++)
        {
            string useColor = _enableColor;

            if (value[i] == '0' && !firstSimvol)
                useColor = _disableColor;


            if (i == value.Length - 1 && !firstSimvol && value[i] != '0')
            {
                useColor = _smolColor;
            }

            if (value[i] != '0' && i != value.Length - 1)
            {
                firstSimvol = true;
                useColor = _enableColor;
            }


            newText += $"<color=#{useColor}>{value[i]}</color>";
        }

        return newText;
    }
}
