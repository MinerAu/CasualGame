using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Messenger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;

    public void AddMessage(string text, Color color)
    {
        for (int i = 0; i < _texts.Length - 1; i++)
        {
            _texts[i].text = _texts[i+1].text;
            _texts[i].color = _texts[i+1].color;
        }

        _texts[_texts.Length - 1].text = $"[{DateTime.Now.ToLongTimeString()}] : {text}";
        _texts[_texts.Length - 1].color = color;
    }
}
