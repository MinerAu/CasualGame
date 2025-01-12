using UnityEngine;

public class Contract
{
    private static int s_nextContractId = 1;

    private int _duration;              //продолжительность контракта
    private int _award;                 //вознаграждение

    public int Id { get; private set; }
    public string Customer { get; private set; }
    public string Item { get; private set; }
    public int Amount { get; private set; }
    public int Duration { get; private set; }
    public int Award { get; private set; }
    public float AcceptedTime { get; private set; }

    public Contract(string customer, string item, int amount, int duration, int award)
    {
        Id = s_nextContractId++;
        Customer = customer;
        Item = item;
        Amount = amount;
        Duration = duration;
        Award = award;
        AcceptedTime = 0f;
    }

    public Contract(int id, string customer, string item, int amount, int duration, int award)
    {
        Id = id;
        Customer = customer;
        Item = item;
        Amount = amount;
        Duration = duration;
        Award = award;
        AcceptedTime = 0f;
    }
}
