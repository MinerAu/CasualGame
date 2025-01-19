using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    private Coroutine _saveProccess;

    [SerializeField] private int _saveInterval = 10;

    [SerializeField] private int _coins;

    [SerializeField] private Wallet2 _wallet;

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
    }

    private void ChangeCoinsAmount(int amount)
    {
        _coins = amount;
        PlayerPrefs.SetInt(nameof(_coins), _coins);
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
