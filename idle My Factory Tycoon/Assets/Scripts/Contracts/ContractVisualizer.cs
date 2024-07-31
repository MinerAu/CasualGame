using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor.Events;
using TMPro;

public class ContractVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _panelContent;
    [SerializeField] private GameObject _contractViewPrototype;
    [SerializeField] private ContractsCreator _contractsCreator;
    [SerializeField] private ContractsManager _contractsManager;

    private Product[] _products;

    private void Start()
    {
        GameObject items = GameObject.Find("Products");
        
        _products = items.GetComponentsInChildren<Product>();
    }

    private void OnEnable()
    {
        if (_contractsCreator != null)
        {
            _contractsCreator.ContractCreated += AddContractView;
        }
    }

    private void OnDisable()
    {
        if (_contractsCreator != null)
        {
            _contractsCreator.ContractCreated -= AddContractView;
        }
    }

    public void AddContractView(Contract contract)
    {
        const string HeaderTextName = "Header";
        const string ItemTextName = "ItemText";
        const string RequiredAmountTextName = "RequiredAmountText";
        const string CustomerTextName = "CustomerText";
        const string DurationTextName = "DurationText";
        const string AwardTextName = "AwardText";

        const string AcceptButtonName = "Accept";
        const string RejectButtonName = "Reject";

        GameObject newContractView = Instantiate(_contractViewPrototype);
        TextMeshProUGUI[] texts;
        UnityEngine.UI.Button[] buttons;
        UnityEngine.UI.Image[] images;

        newContractView.transform.SetParent(_panelContent.transform);

        if (newContractView.TryGetComponent(out RectTransform rect))
        {
            rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0);
            rect.localScale = Vector3.one;
        }

        texts = newContractView.GetComponentsInChildren<TextMeshProUGUI>(false);
        buttons = newContractView.GetComponentsInChildren<UnityEngine.UI.Button>(false);
        images = newContractView.GetComponentsInChildren<UnityEngine.UI.Image>(false);

        foreach (TextMeshProUGUI text in texts)
        {
            switch (text.name)
            {
                case HeaderTextName:
                    text.text = $"Контракт #{contract.Id}";
                    break;

                case ItemTextName:
                    text.text = contract.Item;
                    break;

                case RequiredAmountTextName:
                    text.text = $"Надо: {contract.Amount} шт.";
                    break;

                case CustomerTextName:
                    text.text = $"Заказчик: {contract.Customer}";
                    break;

                case DurationTextName:
                    text.text = $"Срок исполнения: {contract.Duration} нед.";
                    break;

                case AwardTextName:
                    text.text = $"Вознаграждение: {contract.Award}$";
                    break;
            }
        }

        foreach (UnityEngine.UI.Button button in buttons)
        {
            switch (button.name)
            {
                case AcceptButtonName:
                    button.onClick.AddListener(()=>
                    {
                        button.enabled = false;

                        if (AcceptContract(contract))
                        {
                            DestroyContractView(contract.Id);
                        }
                        else
                        {
                            button.enabled = true;
                        }
                    });
                    break;

                case RejectButtonName:
                    button.onClick.AddListener(() =>
                    {
                        button.enabled = false;
                        DestroyContractView(contract.Id);
                    });
                    break;
            }
        }

        Sprite productImage = null;

        foreach (Product product in _products)
        {
            if (product._russianName == contract.Item)
            {
                productImage = product._image;
                break;
            }
        }

        if (productImage != null)
        {
            foreach (UnityEngine.UI.Image image in images)
            {
                if (image.name == "ProductImage")
                {
                    image.sprite = productImage;
                    break;
                }
            }
        }
    }

    /*private Contract GetContract()
    {
        const string HeaderTextName = "Header";
        const string RequiredAmountTextName = "RequiredAmountText";
        const string ItemTextName = "ItemText";
        const string CustomerTextName = "CustomerText";
        const string DurationTextName = "DurationText";
        const string AwardTextName = "AwardText";

        Text[] texts = this.GetComponentsInChildren<Text>(false);

        int id = 0;
        string item = "";
        int amount = 0;
        string customer = "";
        int duration = 0;
        int award = 0;

        foreach (Text text in texts)
        {
            switch (text.name)
            {
                case HeaderTextName:
                    id = int.Parse(text.text.Substring("Контракт #".Length));
                    break;

                case ItemTextName:
                    item = text.text;
                    break;

                case RequiredAmountTextName:
                    amount = int.Parse(text.text.Substring(0, text.text.Length - " шт.".Length).Substring("Надо: ".Length));
                    break;

                case CustomerTextName:
                    customer = text.text.Substring("Заказчик: ".Length);
                    break;

                case DurationTextName:
                    duration = int.Parse(text.text.Substring(0, text.text.Length - " нед.".Length).Substring("Срок исполнения: ".Length));
                    break;

                case AwardTextName:
                    award = int.Parse(text.text.Substring(0, text.text.Length - "$".Length).Substring("Вознаграждение: ".Length));
                    break;
            }
        }

        return new Contract(id, customer, item, amount, duration, award);
    }*/

    private bool AcceptContract(Contract contract)
    {
        return _contractsManager.AddContract(contract);
    }

    private void DestroyContractView(int contractId)
    {
        TextMeshProUGUI headerOfContractViewForDeleted = null;
        TextMeshProUGUI[] texts = _panelContent.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI text in texts)
        {
            if (text.text == $"Контракт #{contractId}")
            {
                headerOfContractViewForDeleted = text;
                break;
            }
        }

        if (headerOfContractViewForDeleted != null)
        {
            Destroy(headerOfContractViewForDeleted.transform.parent.gameObject);
            _contractsCreator.CreateRandomContract();
        }
    }
}
