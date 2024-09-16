using System.Collections.Generic;
using UnityEngine;

public class CallingTheLossWindow : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _loss;
    [SerializeField] private List<GameObject> _menus;
    private IncludesLossWindow _includesLossWindow;

    private void Start()
    {
        _includesLossWindow = new IncludesLossWindow(_menus);
    }

    private void Update()
    {
        IncludesLossWindow();
    }

    private void IncludesLossWindow()
    {
        if (_wallet.GetCoins() <= 0)
        {
            _includesLossWindow.OffWindows();

            _loss.SetActive(true);
        }
    }
}
