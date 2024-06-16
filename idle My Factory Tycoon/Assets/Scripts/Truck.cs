using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Truck : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private GameObject[] points; //�����
    private int isPoint = 0; //����� �����

    public int haveProduct = 0; //����� �� �����
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
            if(haveProduct == 0) //���� �����
            {
                if(canTakeMoney == true)
                {
                    TakeMoney(20/*������ ������ ����������*/); //��������� ����� ����� ��������
                    canTakeMoney = false;
                    Invoke("TruckOff", 3);
                }
                Invoke("TakeProduct", 15);
                haveProduct = 3;
            }
            else if (haveProduct == 1) //�� �������
            {
                isPoint = 1;
                anim.SetBool("isStay", false);
            }
        }
        else if(transform.position == points[1].transform.position) //�� �����
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
        Debug.Log($"����������:{wallet.GetCoins()}");
    }
    private void TakeProduct()
    {
        haveProduct = 1;
        Debug.Log("������� ����!");
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
            Debug.Log($"��������� �����: {wallet.GetCoins() - callPrice}");
        }
    }
}
