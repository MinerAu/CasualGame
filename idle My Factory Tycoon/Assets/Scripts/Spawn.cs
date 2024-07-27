using UnityEngine;

public class Spawn : MonoBehaviour {

    private const int PRICE_MACHINE = 100;
    private const int PRICE_WORKER = 60;

    public GameObject[] machineWorker;
    [SerializeField] private GameObject[] button;

    private Wallet wallet;

    public void Start() {
        wallet = GetComponent<Wallet>();
    }

    public void SpawnWorker(int index) {
        if (wallet.SpendCoins(PRICE_WORKER)) {
            machineWorker[index].SetActive(true);
        }
    }

    public void SpawnMachine(int index) {
        if (wallet.SpendCoins(PRICE_MACHINE)) {
            machineWorker[index].SetActive(true);
        }
    }

    public void Active(int indexMachine) {
        if (wallet.GetCoins() >= PRICE_MACHINE || wallet.GetCoins() >= PRICE_WORKER) {
            button[indexMachine].SetActive(false);
        }
    }
}
