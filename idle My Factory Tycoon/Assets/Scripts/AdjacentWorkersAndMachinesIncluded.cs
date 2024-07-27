using System;
using UnityEngine;

public class AdjacentWorkersAndMachinesIncluded : MonoBehaviour {
    [SerializeField] private Spawn spawn;

    [NonSerialized] public int activeWorkers = 0;

    private int activeMachine = 0;

    public bool IsEnabled() {
        if (spawn != null) {
            for (int i = 0; i < spawn.machineWorker.Length - 1; i++) {
                if (spawn.machineWorker[i].activeSelf && spawn.machineWorker[i + 1].activeSelf) {
                    return true;
                }
            }
        }
        return false;
    }

    private bool IsEnabledWorkers(GameObject worker) => worker.activeSelf;

    public int SumWorkersMachine() {
        activeWorkers = 0;
        for (int i = 0; i < spawn.machineWorker.Length - 1; i++) {
            if (IsEnabledWorkers(spawn.machineWorker[i]) && IsEnabled()) {
                if (spawn.machineWorker[i].CompareTag("Worker")) {
                    activeWorkers += 1;
                }
                else if (spawn.machineWorker[i].CompareTag("Machine")) {
                    activeMachine += 1;
                }
            }
        }
        return activeWorkers;
    }
}
