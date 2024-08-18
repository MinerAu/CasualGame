using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class   ContractSpawner : MonoBehaviour {

    [SerializeField] private List<Image> images;
    [SerializeField] private Button[] buttons;
    [SerializeField] private Button[] cancellationButtons;

    [NonSerialized] public string whatNeedsProduced = "";
    public int countProduct = 0;
    public int countWeek = 0;
    public int coutMoney = 0;
    public bool isCancellationContract = false;

    public void ContractsSpawn(Button clickedButton) {
        var index = Array.IndexOf(buttons, clickedButton);
        for (int i = 0; i < images.Count; i++) {
            if (index != -1 && index == i) {
                whatNeedsProduced = WhatKindProductShouldProduced(i);
                //Destroy(images[i].gameObject);
                TextMeshProUGUI[] texts = images[i].GetComponentsInChildren<TextMeshProUGUI>();
                countProduct = int.Parse(texts[1].text);
                countWeek = int.Parse(texts[2].text[0].ToString());
                coutMoney = int.Parse(texts[3].text);
                break;
            }
        }
    }

    public void CancellationContract(Button clickedButton) {
        var index = Array.IndexOf(cancellationButtons, clickedButton);
        if (index != -1) {
            countProduct = 0;
            countWeek = 0;
            coutMoney = 0;
            isCancellationContract = true;
        }
    }

    public string WhatKindProductShouldProduced(int i) {
        Item[] product = images[i].GetComponentsInChildren<Item>();

        if (product[0].nameItem == "Table") {
            return "Table";
        }
        else if (product[0].nameItem == "Door") {
            return "Door";
        }
        else if (product[0].nameItem == "Saw") {
            return "Saw";
        }

        return "";
    }
}