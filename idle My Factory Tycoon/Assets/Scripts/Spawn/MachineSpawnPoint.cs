using UnityEngine;

public class MachineSpawnPoint : MonoBehaviour
{
    private const int MachineCost = 100;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private Machine _machine;

    public void Spawn()
    {
        if (_wallet.SpendCoins(MachineCost))
        {
            _machine.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
