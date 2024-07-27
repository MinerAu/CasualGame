using UnityEngine;
using UnityEngine.UI;

public class ResourcesViewer : MonoBehaviour
{
    [SerializeField] private ResourcesShop _resourcesShop;

    [SerializeField] private Text _coinsLeft;
    [SerializeField] private Text _boardsLeft;
    [SerializeField] private Text _boxOfNailsLeft;

    private void OnEnable()
    {
        _resourcesShop.ResourcesAmountChanged += ShowResourceAmount;
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
}
