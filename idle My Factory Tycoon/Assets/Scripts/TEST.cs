using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Scrollbar scrollbar;

    public void OnScroll() { 
        float newValue = scrollbar.value * 50;
        text.text = ((int)newValue).ToString();
    }
}
