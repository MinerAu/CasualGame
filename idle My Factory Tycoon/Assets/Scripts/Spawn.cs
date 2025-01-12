using UnityEngine;
using UnityEngine.Events;

public class Spawn : MonoBehaviour {

    private const int PRICE_MACHINE = 100;
    private const int PRICE_WORKER = 60;

    public GameObject[] machineWorker;
    [SerializeField] private GameObject[] button;
    [SerializeField] private Wallet wallet;

    //Masalkin632(2024-08-18): событие для отображения изменившегося количества монет
    public event UnityAction<int> CoinsAmountChanged;

    public void SpawnWorker(int index) {
        ActiveWorker(index);
        if (wallet.SpendCoins(PRICE_WORKER)) {
            machineWorker[index].SetActive(true);
            CoinsAmountChanged?.Invoke(wallet.GetCoins());
        }
    }

    public void SpawnMachine(int index) {
        ActiveMachine(index);
        if (wallet.SpendCoins(PRICE_MACHINE)) {
            machineWorker[index].SetActive(true);
            CoinsAmountChanged?.Invoke(wallet.GetCoins());
        }
    }

    public void ActiveWorker(int indexWorker) {
        if (wallet.GetCoins() >= PRICE_WORKER) {
            button[indexWorker].SetActive(false);
        }
    }

    public void ActiveMachine(int indexMachine) {
        if (wallet.GetCoins() >= PRICE_MACHINE) {
            button[indexMachine].SetActive(false);
        }
    }
}
