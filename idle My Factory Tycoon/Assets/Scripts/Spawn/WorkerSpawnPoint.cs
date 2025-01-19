using UnityEngine;

public class WorkerSpawnPoint : MonoBehaviour
{
    private const int WorkerCost = 60;

    [SerializeField] private Wallet2 _wallet;
    [SerializeField] private Worker _worker;

    public void Spawn()
    {
        if (_wallet.SpendCoins(WorkerCost))
        {
            _worker.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
