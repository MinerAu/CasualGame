using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System;

public class QuantitySet : MonoBehaviour {

    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private TextMeshProUGUI text;

    [NonSerialized]public int quantity; 

    public void ChangeQuantity() {
        int currentValue = (int)(scrollbar.value * 100f);
        quantity = currentValue;
        text.SetText(currentValue.ToString());
    }
}
