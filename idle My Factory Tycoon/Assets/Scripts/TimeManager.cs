using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    [SerializeField] private ProductionGoods productionGoods;
    [SerializeField] private TaxCalculator taxCalculator;

    public float timeScale = 1f; // скорость течения времени
    public float weekDuration = 10f; // Длительность одной игровой недели

    public float currentTime = 0;
    public int currentWeek = 0;

    public TextMeshProUGUI weekText; // Ссылка на UI-элемент где будет отображаться текущая неделя

    private void Start()
    {
        InvokeRepeating("MoveToNextWeek", 0f, weekDuration / timeScale);
    }

    /*private void Update() {
        if (productionGoods.isValue) {
            currentTime += Time.deltaTime * timeScale;

            if (currentTime >= weekDuration) {
                currentTime -= weekDuration;
                currentWeek++;
                OnWeekPassed(currentWeek);
                UpdateWeekUI();
            }
        }
    }*/

    private void MoveToNextWeek()
    {
        Debug.Log("Next week...");

        currentWeek++;
        UpdateWeekUI();

        if (taxCalculator != null)
        {
            taxCalculator.WithholdTax();
        }
    }

    public int GetCurrentWeek() {
        return currentWeek;
    }

    protected virtual void OnWeekPassed(int week) {
        // Вызывается каждую неделю, можно добавить свою логику
        // Debug.Log($"Week {week} has passed!");
    }

    private void UpdateWeekUI() {
        if (weekText != null) {
            weekText.text = $"Week {currentWeek}";
        }
    }
}
