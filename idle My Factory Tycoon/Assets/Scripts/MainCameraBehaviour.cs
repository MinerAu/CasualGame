using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBehaviour : MonoBehaviour
{
    private readonly Vector3 _cameraOffsetRelativeTarget = new Vector3(-25f, 45f, -25f);
    private Transform _target;

    private void Start()
    {
        _target = GameObject.Find("CameraTarget").transform;

        /*if (_target != null)
        {
            Debug.Log(_target.name + " has been found!");
        }
        else
        {
            Debug.Log(_target.name + " has NOT been found!");
        }*/
    }

    private void LateUpdate()
    {
        transform.position = _target.TransformPoint(_cameraOffsetRelativeTarget);
        transform.LookAt(_target);
    }
}