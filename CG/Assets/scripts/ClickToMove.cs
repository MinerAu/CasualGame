using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    private Vector3 TPosition;

    private bool isMove = false;
    [SerializeField] private float speed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            PositionTrigger();
        }

        if (isMove)
        {
            IsMoving();
        }
    }

    void PositionTrigger()
    {
        TPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TPosition.z = transform.position.z;

        isMove = true;
    }

    void IsMoving()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, TPosition);
        transform.position = Vector3.MoveTowards(transform.position, TPosition, speed * Time.deltaTime);

        if (transform.position == TPosition)
        {
            isMove = false;
        }
    }
}
