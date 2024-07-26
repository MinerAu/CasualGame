using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesViewer : MonoBehaviour
{
    private string[] _resourceNames = new string[]
    {
        "board",
        "box of nails",
        "Metal Sheet",
        "A box of screws",
        "Metal Alloy",
        "Rubber",
        "Plastic",
        "Electrical circuit"
    };

    [SerializeField] private ResourcesShop _resourcesShop;
    [SerializeField] private Text _coinsLeft;
    [SerializeField] private TextMeshProUGUI _boardsLeft;
    [SerializeField] private TextMeshProUGUI _boxOfNailsLeft;
    [SerializeField] private TextMeshProUGUI _metalSheetsLeft;
    [SerializeField] private TextMeshProUGUI _boxOfScrewsLeft;
    [SerializeField] private TextMeshProUGUI _metalAlloyLeft;
    [SerializeField] private TextMeshProUGUI _rubberLeft;
    [SerializeField] private TextMeshProUGUI _plasticLeft;
    [SerializeField] private TextMeshProUGUI _electricalCircuitLeft;

    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _resourcesShop.ResourcesAmountChanged += ShowResourceAmount;
    }

    private void Start()
    {
        foreach (string resourceName in _resourceNames)
        {
            ShowResourceAmount(resourceName, _warehouse.GetResource(resourceName).quantityItem);
        }

        ShowCoinsAmount(_wallet.GetCoins());
    }

    private void OnDisable()
    {
        _resourcesShop.ResourcesAmountChanged -= ShowResourceAmount;
    }

    public void ShowResourceAmount(string resourceName, int resourceAmount)
    {
        switch (resourceName)
        {
            case "coins":
                ShowCoinsAmount(resourceAmount);
                break;

            case "board":
                ShowBoardsAmount(resourceAmount);
                break;

            case "box of nails":
                ShowBoxOfNailsAmount(resourceAmount);
                break;

            case "Metal Sheet":
                ShowMetalSheetsAmount(resourceAmount);
                break;

            case "A box of screws":
                ShowBoxOfScrewsAmount(resourceAmount);
                break;

            case "Metal Alloy":
                ShowMetalAlloyAmount(resourceAmount);
                break;

            case "Rubber":
                ShowRubberAmount(resourceAmount);
                break;

            case "Plastic":
                ShowPlasticAmount(resourceAmount);
                break;

            case "Electrical circuit":
                ShowElectricalCircuitAmount(resourceAmount);
                break;

            default:
                Debug.Log("Unknown resource name");
                break;
        }
    }

    private void ShowCoinsAmount(int amount)
    {
        _coinsLeft.text = $"{amount}$";
    }

    private void ShowBoardsAmount(int amount)
    {
        _boardsLeft.text = $"x{amount}";
    }

    private void ShowBoxOfNailsAmount(int amount)
    {
        _boxOfNailsLeft.text = $"x{amount}";
    }

    private void ShowMetalSheetsAmount(int amount)
    {
        _metalSheetsLeft.text = $"x{amount}";
    }

    private void ShowBoxOfScrewsAmount(int amount)
    {
        _boxOfScrewsLeft.text = $"x{amount}";
    }

    private void ShowMetalAlloyAmount(int amount)
    {
        _metalAlloyLeft.text = $"x{amount}";
    }

    private void ShowRubberAmount(int amount)
    {
        _rubberLeft.text = $"x{amount}";
    }

    private void ShowPlasticAmount(int amount)
    {
        _plasticLeft.text = $"x{amount}";
    }

    private void ShowElectricalCircuitAmount(int amount)
    {
        _electricalCircuitLeft.text = $"x{amount}";
    }
}
