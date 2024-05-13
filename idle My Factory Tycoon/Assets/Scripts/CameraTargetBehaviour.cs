using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargetBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 4.0f;

    private Vector3 _forward;
    private Vector3 _right;

    // Start is called before the first frame update
    private void Start()
    {
        _forward = Camera.main.transform.forward;
        _forward.y = 0;
        _forward = Vector3.Normalize(_forward);

        _right = Quaternion.Euler(new Vector3(0, 90, 0)) * _forward;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
    }

    private void Move()
    {
        //Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));

        Vector3 rightMovement = _right * _moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = _forward * _moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //transform.forward = heading;
        transform.position += rightMovement + upMovement;

    }
}
