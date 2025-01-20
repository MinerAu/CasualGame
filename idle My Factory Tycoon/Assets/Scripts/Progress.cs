using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    private Coroutine _saveProccess;

    [SerializeField] private int _saveInterval = 10;

    [SerializeField] private int _coins;
    [SerializeField] private int _boards;
    [SerializeField] private int _boxesOfNails;
    [SerializeField] private int _boxesOfScrews;
    [SerializeField] private int _electricalCircuits;
    [SerializeField] private int _metalAlloys;
    [SerializeField] private int _metalSheets;
    [SerializeField] private int _plastics;
    [SerializeField] private int _rubbers;
    

    [SerializeField] private Wallet2 _wallet;
    [SerializeField] private Warehouse _warehouse;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        Load();
    }

    private void OnEnable()
    {
        _wallet.CoinsAmountChanged += ChangeCoinsAmount;
        _warehouse.ResourcesAmountChanged += ResourceAmountChanged;

        _saveProccess = StartCoroutine(SaveProccess());
    }

    private void OnDisable()
    {
        _wallet.CoinsAmountChanged -= ChangeCoinsAmount;

        StopCoroutine(_saveProccess);
    }

    private void Save()
    {
        PlayerPrefs.Save();
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey(nameof(_coins)))
        {
            _coins = PlayerPrefs.GetInt(nameof(_coins));
            _wallet.SetCoins(_coins);
        }

        if (PlayerPrefs.HasKey(nameof(_boards)))
        {
            _boards = PlayerPrefs.GetInt(nameof(_boards));
            _warehouse.SetResourceAmount("board", _boards);
        }

        if (PlayerPrefs.HasKey(nameof(_boxesOfScrews)))
        {
            _boxesOfScrews = PlayerPrefs.GetInt(nameof(_boxesOfScrews));
            _warehouse.SetResourceAmount("A box of screws", _boxesOfScrews);
        }

        if (PlayerPrefs.HasKey(nameof(_boxesOfNails)))
        {
            _boxesOfNails = PlayerPrefs.GetInt(nameof(_boxesOfNails));
            _warehouse.SetResourceAmount("box of nails", _boxesOfNails);
        }

        if (PlayerPrefs.HasKey(nameof(_metalSheets)))
        {
            _metalSheets = PlayerPrefs.GetInt(nameof(_metalSheets));
            _warehouse.SetResourceAmount("Metal Sheet", _metalSheets);
        }

        if (PlayerPrefs.HasKey(nameof(_metalAlloys)))
        {
            _metalAlloys = PlayerPrefs.GetInt(nameof(_metalAlloys));
            _warehouse.SetResourceAmount("Metal Alloy", _metalAlloys);
        }

        if (PlayerPrefs.HasKey(nameof(_rubbers)))
        {
            _rubbers = PlayerPrefs.GetInt(nameof(_rubbers));
            _warehouse.SetResourceAmount("Rubber", _rubbers);
        }

        if (PlayerPrefs.HasKey(nameof(_plastics)))
        {
            _plastics = PlayerPrefs.GetInt(nameof(_plastics));
            _warehouse.SetResourceAmount("Plastic", _plastics);
        }

        if (PlayerPrefs.HasKey(nameof(_electricalCircuits)))
        {
            _electricalCircuits = PlayerPrefs.GetInt(nameof(_electricalCircuits));
            _warehouse.SetResourceAmount("Electrical circuit", _electricalCircuits);
        }
    }

    private void ChangeCoinsAmount(int amount)
    {
        _coins = amount;
        PlayerPrefs.SetInt(nameof(_coins), _coins);
    }

    private void ResourceAmountChanged(string resourceName, int resourceAmount)
    {
        switch (resourceName)
        {
            case "board":
                ChangeBoards(resourceAmount);
                break;

            case "box of nails":
                ChangeBoxesOfNails(resourceAmount);
                break;

            case "Metal Sheet":
                ChangeMetalSheets(resourceAmount);
                break;

            case "A box of screws":
                ChangeBoxesOfScrews(resourceAmount);
                break;

            case "Metal Alloy":
                ChangeMetalAlloys(resourceAmount);
                break;

            case "Rubber":
                ChangeRubbers(resourceAmount);
                break;

            case "Plastic":
                ChangePlastics(resourceAmount);
                break;

            case "Electrical circuit":
                ChangeElectricalCircuits(resourceAmount);
                break;

            default:
                Debug.Log("Unknown resource name");
                break;

        }
    }

    private void ChangeBoards(int amount)
    {
        _boards = amount;
        PlayerPrefs.SetInt(nameof(_boards), _boards);
    }

    private void ChangeBoxesOfNails(int amount)
    {
        _boxesOfNails = amount;
        PlayerPrefs.SetInt(nameof(_boxesOfNails), _boxesOfNails);
    }

    private void ChangeBoxesOfScrews(int amount)
    {
        _boxesOfScrews = amount;
        PlayerPrefs.SetInt(nameof(_boxesOfScrews), _boxesOfScrews);
    }

    private void ChangeElectricalCircuits(int amount)
    {
        _electricalCircuits = amount;
        PlayerPrefs.SetInt(nameof(_electricalCircuits), _electricalCircuits);
    }

    private void ChangeMetalAlloys(int amount)
    {
        _metalAlloys = amount;
        PlayerPrefs.SetInt(nameof(_metalAlloys), _metalAlloys);
    }

    private void ChangeMetalSheets(int amount)
    {
        _metalSheets = amount;
        PlayerPrefs.SetInt(nameof(_metalSheets), _metalSheets);
    }

    private void ChangePlastics(int amount)
    {
        _plastics = amount;
        PlayerPrefs.SetInt(nameof(_plastics), _plastics);
    }

    private void ChangeRubbers(int amount)
    {
        _rubbers = amount;
        PlayerPrefs.SetInt(nameof(_rubbers), _rubbers);
    }

    private IEnumerator SaveProccess()
    {
        var delay = new WaitForSeconds(_saveInterval);

        while (true)
        {
            yield return delay;
            Save();
        }
    }
}
