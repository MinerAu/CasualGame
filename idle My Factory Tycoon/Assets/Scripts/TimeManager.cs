using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    [SerializeField] private ProductionGoods productionGoods;
    [SerializeField] private TaxCalculator taxCalculator;

    public float timeScale = 1f; // �������� ������� �������
    public float weekDuration = 10f; // ������������ ����� ������� ������

    public float currentTime = 0;
    public int currentWeek = 0;

    public TextMeshProUGUI weekText; // ������ �� UI-������� ��� ����� ������������ ������� ������

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
        // ���������� ������ ������, ����� �������� ���� ������
        // Debug.Log($"Week {week} has passed!");
    }

    private void UpdateWeekUI() {
        if (weekText != null) {
            weekText.text = $"Week {currentWeek}";
        }
    }
}
