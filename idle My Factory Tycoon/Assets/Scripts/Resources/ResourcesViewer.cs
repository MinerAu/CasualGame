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
    [SerializeField] private Spawn _spawn;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Wallet _wallet;

    [SerializeField] private TextMeshProUGUI _coinsLeft;
    [SerializeField] private TextMeshProUGUI _boardsLeft;
    [SerializeField] private TextMeshProUGUI _boardsLeftAlternate;
    [SerializeField] private TextMeshProUGUI _boxOfNailsLeft;
    [SerializeField] private TextMeshProUGUI _boxOfNailsLeftAlternate;
    [SerializeField] private TextMeshProUGUI _metalSheetsLeft;
    [SerializeField] private TextMeshProUGUI _metalSheetsLeftAlternate;
    [SerializeField] private TextMeshProUGUI _boxOfScrewsLeft;
    [SerializeField] private TextMeshProUGUI _boxOfScrewsLeftAlternate;
    [SerializeField] private TextMeshProUGUI _metalAlloyLeft;
    [SerializeField] private TextMeshProUGUI _metalAlloyLeftAlternate;
    [SerializeField] private TextMeshProUGUI _rubberLeft;
    [SerializeField] private TextMeshProUGUI _rubberLeftAlternate;
    [SerializeField] private TextMeshProUGUI _plasticLeft;
    [SerializeField] private TextMeshProUGUI _plasticLeftAlternate;
    [SerializeField] private TextMeshProUGUI _electricalCircuitLeft;
    [SerializeField] private TextMeshProUGUI _electricalCircuitLeftAlternate;

    private void OnEnable()
    {
        _resourcesShop.ResourcesAmountChanged += ShowResourceAmount;
        _spawn.CoinsAmountChanged += ShowCoinsAmount;
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
        _spawn.CoinsAmountChanged -= ShowCoinsAmount;
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
        _coinsLeft.text = $"x{amount}$";
    }

    private void ShowBoardsAmount(int amount)
    {
        string text = $"x{amount}";

        _boardsLeft.text = text;

        if (_boardsLeftAlternate != null)
        {
            _boardsLeftAlternate.text = text;
        }
    }

    private void ShowBoxOfNailsAmount(int amount)
    {
        string text = $"x{amount}";

        _boxOfNailsLeft.text = text;

        if (_boxOfNailsLeftAlternate != null)
        {
            _boxOfNailsLeftAlternate.text = text;
        }
    }

    private void ShowMetalSheetsAmount(int amount)
    {
        string text = $"x{amount}";

        _metalSheetsLeft.text = text;

        if (_metalSheetsLeftAlternate != null)
        {
            _metalSheetsLeftAlternate.text = text;
        }
    }

    private void ShowBoxOfScrewsAmount(int amount)
    {
        string text = $"x{amount}";

        _boxOfScrewsLeft.text = text;

        if (_boxOfScrewsLeftAlternate != null)
        {
            _boxOfScrewsLeftAlternate.text = text;
        }
    }

    private void ShowMetalAlloyAmount(int amount)
    {
        string text = $"x{amount}";

        _metalAlloyLeft.text = text;

        if (_metalAlloyLeftAlternate != null)
        {
            _metalAlloyLeftAlternate.text = text;
        }
    }

    private void ShowRubberAmount(int amount)
    {
        string text = $"x{amount}";

        _rubberLeft.text = text;

        if (_rubberLeftAlternate != null )
        {
            _rubberLeftAlternate.text = text;
        }
    }

    private void ShowPlasticAmount(int amount)
    {
        string text = $"{amount}";

        _plasticLeft.text = text;

        if (_plasticLeftAlternate != null)
        {
            _plasticLeftAlternate.text = text;
        }
    }

    private void ShowElectricalCircuitAmount(int amount)
    {
        string text = $"x{amount}";

        _electricalCircuitLeft.text = $"x{amount}";

        if (_electricalCircuitLeftAlternate != null)
        {
            _electricalCircuitLeftAlternate.text = text;
        }
    }
}