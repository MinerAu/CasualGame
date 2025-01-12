using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ProductsViewer : MonoBehaviour
{
    private string[] _productNames = new string[]
    {
        "Chair",
        "Door",
        "Table",
        "Hammer",
        "Saw",
        "Wheel",
        "Engine",
        "Bath",
        "Screwdriver",
        "Smartphone"
    };

    private string[] _productRusNames = new string[]
    {
        "Стул",
        "Дверь",
        "Стол",
        "Молоток",
        "Пила",
        "Колесо",
        "Двигатель",
        "Ванная",
        "Шуруповёрт",
        "Смартфон"
    };

    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private TextMeshProUGUI _chairsLeft;
    [SerializeField] private TextMeshProUGUI _doorsLeft;
    [SerializeField] private TextMeshProUGUI _tablesLeft;
    [SerializeField] private TextMeshProUGUI _hammersLeft;
    [SerializeField] private TextMeshProUGUI _sawsLeft;
    [SerializeField] private TextMeshProUGUI _wheelsLeft;
    [SerializeField] private TextMeshProUGUI _enginesLeft;
    [SerializeField] private TextMeshProUGUI _bathesLeft;
    [SerializeField] private TextMeshProUGUI _screwdriversLeft;
    [SerializeField] private TextMeshProUGUI _smartphonesLeft;

    private void OnEnable()
    {
        _warehouse.ProductsAmountChanged += ShowProductsAmount;
        
        foreach (string productName in _productNames)
        {
            ShowProductsAmount(productName, _warehouse.GetProductAmount(productName));
        }
    }

    private void OnDisable()
    {
        _warehouse.ProductsAmountChanged -= ShowProductsAmount;
    }
    public void ShowProductsAmount(string productName, int productAmount)
    {
        switch (productName)
        {
            case "Chair":
            case "Стул":
                ShowChairsAmount(productAmount);
                break;

            case "Door":
            case "Дверь":
                ShowDoorsAmount(productAmount);
                break;

            case "Table":
            case "Стол":
                ShowTablesAmount(productAmount);
                break;

            case "Hammer":
            case "Молоток":
                ShowHammersAmount(productAmount);
                break;
            
            case "Saw":
            case "Пила":
                ShowSawsAmount(productAmount);
                break;
            
            case "Wheel":
            case "Колесо":
                ShowWheelsAmount(productAmount);
                break;
            
            case "Engine":
            case "Двигатель":
                ShowEnginesAmount(productAmount);
                break;
            
            case "Bath":
            case "Ванная":
                ShowBathesAmount(productAmount);
                break;

            case "Screwdriver":
            case "Шуруповёрт":
                ShowScrewdriversAmount(productAmount);
                break;
            
            case "Smartphone":
            case "Смартфон":
                ShowSmartphonesAmount(productAmount);
                break;
        }
    }

    private void ShowChairsAmount(int amount)
    {
        string text = $"x{amount}";

        if (_chairsLeft != null)
        {
            _chairsLeft.text = text;
        }
    }
    
    private void ShowDoorsAmount(int amount)
    {
        string text = $"x{amount}";

        if (_doorsLeft != null)
        {
            _doorsLeft.text = text;
        }
    }

    private void ShowTablesAmount(int amount)
    {
        string text = $"x{amount}";

        if (_tablesLeft != null)
        {
            _tablesLeft.text = text;
        }
    }

    private void ShowHammersAmount(int amount)
    {
        string text = $"x{amount}";

        if (_hammersLeft != null)
        {
            _hammersLeft.text = text;
        }
    }

    private void ShowSawsAmount(int amount)
    {
        string text = $"x{amount}";

        if (_sawsLeft != null)
        {
            _sawsLeft.text = text;
        }
    }

    private void ShowWheelsAmount(int amount)
    {
        string text = $"x{amount}";

        if (_wheelsLeft != null)
        {
            _wheelsLeft.text = text;
        }
    }

    private void ShowEnginesAmount(int amount)
    {
        string text = $"x{amount}";

        if (_enginesLeft != null)
        {
            _enginesLeft.text = text;
        }
    }

    private void ShowBathesAmount(int amount)
    {
        string text = $"x{amount}";

        if (_bathesLeft != null)
        {
            _bathesLeft.text = text;
        }
    }

    private void ShowScrewdriversAmount(int amount)
    {
        string text = $"x{amount}";

        if (_screwdriversLeft != null)
        {
            _screwdriversLeft.text = text;
        }
    }

    private void ShowSmartphonesAmount(int amount)
    {
        string text = $"x{amount}";

        if (_smartphonesLeft != null)
        {
            _smartphonesLeft.text = text;
        }
    }
}
