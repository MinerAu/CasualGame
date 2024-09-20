using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private Image _panel;

    private VerticalLayoutGroup _vlg;

    private bool _isExpanded = true;

    private void Start()
    {
        _vlg = GetComponent<VerticalLayoutGroup>();
    }

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

    public void ChangePanelSize()
    {
        if (_isExpanded)
        {
            CollapsePanel();
        }
        else
        {
            ExpandPanel();
        }
    }

    private void CollapsePanel()
    {
        for (int i = 0; i < _texts.Length - 1; i++)
        {
            _texts[i].enabled = false;
        }

        _panel.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _texts[_texts.Length - 1].rectTransform.sizeDelta.y);
        _vlg.reverseArrangement = true;

        _isExpanded = false;
    }

    private void ExpandPanel()
    {
        for (int i = 0; i < _texts.Length - 1; i++)
        {
            _texts[i].enabled = true;
        }

        _panel.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _texts[_texts.Length - 1].rectTransform.sizeDelta.y * _texts.Length);
        _vlg.reverseArrangement = false;

        _isExpanded = true;
    }
}
