using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    [SerializeField] private int _bathes;
    [SerializeField] private int _chairs;
    [SerializeField] private int _doors;
    [SerializeField] private int _engines;
    [SerializeField] private int _hammers;
    [SerializeField] private int _saws;
    [SerializeField] private int _screwdrivers;
    [SerializeField] private int _smartphones;
    [SerializeField] private int _tables;
    [SerializeField] private int _wheels;

    [SerializeField] private List<Worker> _workers;
    [SerializeField] private List<GameObject> _workerButtons;
    [SerializeField] private List<Machine> _machines;
    [SerializeField] private List<GameObject> _machineButtons;

    [SerializeField] private Wallet2 _wallet;
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private ContractsManager _contractsManager;

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
        _warehouse.ProductsAmountChanged += ProductAmountChanged;

        _saveProccess = StartCoroutine(SaveProccess());
    }

    private void OnDisable()
    {
        _wallet.CoinsAmountChanged -= ChangeCoinsAmount;
        _warehouse.ResourcesAmountChanged -= ResourceAmountChanged;
        _warehouse.ProductsAmountChanged -= ProductAmountChanged;

        StopCoroutine(_saveProccess);
    }

    private void Save()
    {
        int index = 0;
        while (index < _workers.Count)
        {
            string workerName = $"_worker{index + 1}";

            PlayerPrefs.SetInt(workerName, _workers[index].gameObject.activeSelf ? 1 : 0);

            ++index;
        }

        index = 0;
        while (index < _machines.Count)
        {
            string machineName = $"_machine{index + 1}";

            PlayerPrefs.SetInt(machineName, _machines[index].gameObject.activeSelf ? 1 : 0);

            ++index;
        }

        index = 0;
        PlayerPrefs.SetInt("_contractsCount", _contractsManager.GetContractsCount());
        while (index < _contractsManager.GetContractsCount())
        {
            PlayerPrefs.SetInt($"_contract{index + 1}Id", _contractsManager.GetContractId(index));
            PlayerPrefs.SetString($"_contract{index + 1}Customer", _contractsManager.GetContractCustomer(index));
            PlayerPrefs.SetString($"_contract{index + 1}Item", _contractsManager.GetContractItem(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Amount", _contractsManager.GetContractAmount(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Duration", _contractsManager.GetContractDuration(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Award", _contractsManager.GetContractAward(index));
            PlayerPrefs.SetFloat($"_contract{index + 1}AcceptedTime", _contractsManager.GetContractAcceptedTime(index));

            Debug.Log(_contractsManager.GetContractAsString(index));

            ++index;
        }

        PlayerPrefs.Save();
    }

    /*public int Id { get; private set; }
    public string Customer { get; private set; }
    public string Item { get; private set; }
    public int Amount { get; private set; }
    public int Duration { get; private set; }
    public int Award { get; private set; }
    public float AcceptedTime { get; private set; }*/

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

        /*[SerializeField] private int _bathes;
        [SerializeField] private int _chairs;
        [SerializeField] private int _doors;
        [SerializeField] private int _engines;
        [SerializeField] private int _hammers;
        [SerializeField] private int _saws;
        [SerializeField] private int _screwdrivers;
        [SerializeField] private int _smartphones;
        [SerializeField] private int _tables;
        [SerializeField] private int _wheels;*/

        if (PlayerPrefs.HasKey(nameof(_bathes)))
        {
            _bathes = PlayerPrefs.GetInt(nameof(_bathes));
            _warehouse.SetProductAmount("Bath", _bathes);
            _warehouse.SetProductAmount("Ванная", _bathes);
        }

        if (PlayerPrefs.HasKey(nameof(_chairs)))
        {
            _chairs = PlayerPrefs.GetInt(nameof(_chairs));
            _warehouse.SetProductAmount("Chair", _chairs);
            _warehouse.SetProductAmount("Стул", _chairs);
        }

        if (PlayerPrefs.HasKey(nameof(_doors)))
        {
            _doors = PlayerPrefs.GetInt(nameof(_doors));
            _warehouse.SetProductAmount("Door", _doors);
            _warehouse.SetProductAmount("Дверь", _doors);
        }

        if (PlayerPrefs.HasKey(nameof(_engines)))
        {
            _engines = PlayerPrefs.GetInt(nameof(_engines));
            _warehouse.SetProductAmount("Engine", _engines);
            _warehouse.SetProductAmount("Двигатель", _engines);
        }

        if (PlayerPrefs.HasKey(nameof(_hammers)))
        {
            _hammers = PlayerPrefs.GetInt(nameof(_hammers));
            _warehouse.SetProductAmount("Hammer", _hammers);
            _warehouse.SetProductAmount("Молоток", _hammers);
        }

        if (PlayerPrefs.HasKey(nameof(_saws)))
        {
            _saws = PlayerPrefs.GetInt(nameof(_saws));
            _warehouse.SetProductAmount("Saw", _saws);
            _warehouse.SetProductAmount("Пила", _saws);
        }

        if (PlayerPrefs.HasKey(nameof(_screwdrivers)))
        {
            _screwdrivers = PlayerPrefs.GetInt(nameof(_screwdrivers));
            _warehouse.SetProductAmount("Screwdriver", _screwdrivers);
            _warehouse.SetProductAmount("Шуруповёрт", _screwdrivers);
        }

        if (PlayerPrefs.HasKey(nameof(_smartphones)))
        {
            _smartphones = PlayerPrefs.GetInt(nameof(_smartphones));
            _warehouse.SetProductAmount("Smartphone", _smartphones);
            _warehouse.SetProductAmount("Смартфон", _smartphones);
        }

        if (PlayerPrefs.HasKey(nameof(_tables)))
        {
            _tables = PlayerPrefs.GetInt(nameof(_tables));
            _warehouse.SetProductAmount("Table", _tables);
            _warehouse.SetProductAmount("Стол", _tables);
        }

        if (PlayerPrefs.HasKey(nameof(_wheels)))
        {
            _wheels = PlayerPrefs.GetInt(nameof(_wheels));
            _warehouse.SetProductAmount("Wheel", _wheels);
            _warehouse.SetProductAmount("Колесо", _wheels);
        }

        int index = 0;
        while (index < _workers.Count)
        {
            string workerName = $"_worker{index + 1}";

            if (PlayerPrefs.HasKey(workerName))
            {
                _workers[index].gameObject.SetActive(PlayerPrefs.GetInt(workerName) >= 1 ? true : false);
                _workerButtons[index].gameObject.SetActive(PlayerPrefs.GetInt(workerName) >= 1 ? false : true);
            }
            ++index;
        }

        index = 0;
        while (index < _machines.Count)
        {
            string machineName = $"_machine{index + 1}";

            if (PlayerPrefs.HasKey(machineName))
            {
                _machines[index].gameObject.SetActive(PlayerPrefs.GetInt(machineName) >= 1 ? true : false);
                _machineButtons[index].gameObject.SetActive(PlayerPrefs.GetInt(machineName) >= 1 ? false : true);
            }

            ++index;
        }

        index = 0;
        _contractsManager.ClearContracts();
        while (index < PlayerPrefs.GetInt("_contractsCount"))
        {
            Contract contract = new Contract(PlayerPrefs.GetInt($"_contract{index + 1}Id"),
                                             PlayerPrefs.GetString($"_contract{index + 1}Customer"),
                                             PlayerPrefs.GetString($"_contract{index + 1}Item"),
                                             PlayerPrefs.GetInt($"_contract{index + 1}Amount"),
                                             PlayerPrefs.GetInt($"_contract{index + 1}Duration"),
                                             PlayerPrefs.GetInt($"_contract{index + 1}Award"));
            _contractsManager.AddContract(contract);
            ++index;
        }

        /*index = 0;
        PlayerPrefs.SetInt("_contractsCount", _contractsManager.GetContractsCount());
        while (index < _contractsManager.GetContractsCount())
        {
            PlayerPrefs.SetInt($"_contract{index + 1}Id", _contractsManager.GetContractId(index));
            PlayerPrefs.SetString($"_contract{index + 1}Customer", _contractsManager.GetContractCustomer(index));
            PlayerPrefs.SetString($"_contract{index + 1}Item", _contractsManager.GetContractItem(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Amount", _contractsManager.GetContractAmount(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Duration", _contractsManager.GetContractDuration(index));
            PlayerPrefs.SetInt($"_contract{index + 1}Award", _contractsManager.GetContractAward(index));
            PlayerPrefs.SetFloat($"_contract{index + 1}AcceptedTime", _contractsManager.GetContractAcceptedTime(index));

            ++index;
        }*/
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

    private void ProductAmountChanged(string productName, int productAmount)
    {
        switch (productName)
        {
            case "Chair":
            case "Стул":
                ChangeChairs(productAmount);
                break;

            case "Door":
            case "Дверь":
                ChangeDoors(productAmount);
                break;

            case "Table":
            case "Стол":
                ChangeTables(productAmount);
                break;

            case "Hammer":
            case "Молоток":
                ChangeHammers(productAmount);
                break;

            case "Saw":
            case "Пила":
                ChangeSaws(productAmount);
                break;

            case "Wheel":
            case "Колесо":
                ChangeWheels(productAmount);
                break;

            case "Engine":
            case "Двигатель":
                ChangeWheels(productAmount);
                break;

            case "Bath":
            case "Ванная":
                ChangeBathes(productAmount);
                break;

            case "Screwdriver":
            case "Шуруповёрт":
                ChangeScrewdrivers(productAmount);
                break;

            case "Smartphone":
            case "Смартфон":
                ChangeSmartphones(productAmount);
                break;
        }
    }

    private void ChangeBathes(int amount)
    {
        _bathes = amount;
        PlayerPrefs.SetInt(nameof(_bathes), _bathes);
    }

    private void ChangeChairs(int amount)
    {
        _chairs = amount;
        PlayerPrefs.SetInt(nameof(_chairs), _chairs);
    }

    private void ChangeDoors(int amount)
    {
        _doors = amount;
        PlayerPrefs.SetInt(nameof(_doors), _doors);
    }

    private void ChangeEngines(int amount)
    {
        _engines = amount;
        PlayerPrefs.SetInt(nameof(_engines), _engines);
    }

    private void ChangeHammers(int amount)
    {
        _hammers = amount;
        PlayerPrefs.SetInt(nameof(_hammers), _hammers);
    }

    private void ChangeSaws(int amount)
    {
        _saws = amount;
        PlayerPrefs.SetInt(nameof(_saws), _saws);
    }

    private void ChangeScrewdrivers(int amount)
    {
        _screwdrivers = amount;
        PlayerPrefs.SetInt(nameof(_screwdrivers), _screwdrivers);
    }

    private void ChangeSmartphones(int amount)
    {
        _smartphones = amount;
        PlayerPrefs.SetInt(nameof(_smartphones), _smartphones);
    }

    private void ChangeTables(int amount)
    {
        _tables = amount;
        PlayerPrefs.SetInt(nameof(_tables), _tables);
    }

    private void ChangeWheels(int amount)
    {
        _wheels = amount;
        PlayerPrefs.SetInt(nameof(_wheels), _wheels);
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
