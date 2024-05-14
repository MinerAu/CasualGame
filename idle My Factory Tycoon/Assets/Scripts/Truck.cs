using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Truck : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private GameObject[] points; //точки
    private int isPoint = 0; //какая точка

    public int haveProduct = 0; //готов ли товар
    public bool canTakeMoney = false;

    [SerializeField] private int callPrice = 100;

    private Animator anim;

    public Wallet wallet;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveTruck();
    }
    private void MoveTruck()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[isPoint].transform.position, speed * Time.deltaTime);
    }
    private void ChoosePoint()
    {
        if(transform.position == points[0].transform.position)
        {
            if(haveProduct == 0) //ждем товар
            {
                if(canTakeMoney == true)
                {
                    TakeMoney(20/*должна стоять переменная*/); //заработал денег после доставки
                    canTakeMoney = false;
                    Invoke("TruckOff", 3);
                }
                Invoke("TakeProduct", 15);
                haveProduct = 3;
            }
            else if (haveProduct == 1) //на продажу
            {
                isPoint = 1;
                anim.SetBool("isStay", false);
            }
        }
        else if(transform.position == points[1].transform.position) //на завод
        {
            isPoint = 0;
            canTakeMoney = true;
            haveProduct = 0;
            anim.SetBool("isStay", true);
        }
    }
    public void TakeMoney(int salary)
    {
        wallet.AddCoins(salary);
        Debug.Log($"Заработано:{wallet.GetCoins()}");
    }
    private void TakeProduct()
    {
        haveProduct = 1;
        Debug.Log("Продукт взят!");
    }
    private void TruckOff()
    {
        gameObject.SetActive(false);
    }
    public void CallTruck()
    {
        if(wallet.GetCoins() >= callPrice)
        {
            gameObject.SetActive(true);
            ChoosePoint();
        }
        else
        {
            Debug.Log($"Нехватает денег: {wallet.GetCoins() - callPrice}");
        }
    }
}
