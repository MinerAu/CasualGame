using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public float timeScale = 1f; // �������� ������� �������
    public float weekDuration = 30f; // ������������ ����� ������� ������

    private float currentTime = 0f;
    private int currentWeek = 0;

    public Text weekText; // ������ �� UI-������� ��� ����� ������������ ������� ������

    private void Start()
    {
        InvokeRepeating("UpdateWeek", 0f, weekDuration / timeScale);
    }

    private void UpdateWeek()
    {
        currentWeek++;
        OnWeekPassed(currentWeek);
        UpdateWeekUI();
    }

    private void Update()
    {
        currentTime += Time.deltaTime * timeScale;
    }

    public int GetCurrentWeek()
    {
        return currentWeek;
    }

    protected virtual void OnWeekPassed(int week)
    {
        // ���������� ������ ������, ����� �������� ���� ������
        Debug.Log($"Week {week} has passed!");
    }

    private void UpdateWeekUI()
    {
        if ( weekText != null )
        {
            weekText.text = $"Week {currentWeek}";
        }
    }
}
