using UnityEngine;

public class ContractSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] contract;
    [SerializeField] private Transform pivot;

    private float timer;

    private void Update() {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > 5f) {
            Instantiate(contract[Random.Range(0, 3)], pivot);
            timer = 0;
        }
    }
}
