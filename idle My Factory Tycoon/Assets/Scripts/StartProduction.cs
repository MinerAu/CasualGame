using UnityEngine;

public class StartProduction : MonoBehaviour {

    [SerializeField] private Animator[] animator;

    private AdjacentWorkersAndMachinesIncluded adjacentWorkersAndMachinesIncluded;

    public int weekDuration = 40;
    public int speedWorkersLVL1 = 10;

    private void Start() {
        adjacentWorkersAndMachinesIncluded = GetComponent<AdjacentWorkersAndMachinesIncluded>();
    }

    /*public void StartProductionAnimation() {
        foreach (Animator anim in animator) {
            if (adjacentWorkersAndMachinesIncluded.IsEnabled()) {
                anim.SetBool("IsAnimating", true);
            }
        }
    }

    public void StopProductionAnimation() {
        foreach (Animator anim in animator) {
            if (adjacentWorkersAndMachinesIncluded.IsEnabled()) {
                anim.SetBool("IsAnimating", false);
            }
        }
    }*/
}
