using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Yandex : MonoBehaviour
{
    [DllImport("_Internal")]
    private static extern void ShowAdv();

    public void AddShowAd()
    {
        ShowAdv();
    }
}
