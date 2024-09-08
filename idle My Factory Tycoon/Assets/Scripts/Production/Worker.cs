using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Worker : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private Machine _machine;

    private bool _isWorking = false;
    private Animator _animator;

    private bool IsActive => gameObject.activeSelf;
    private bool HasMachine => _machine != null && _machine.gameObject.activeSelf;
    
    public bool IsReadyForWork => IsActive && HasMachine && _isWorking == false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public IEnumerator Produce(Product product)
    {
        if (IsReadyForWork == false)
        {
            yield return null;
        }
        else
        {
            Debug.Log("PRODUCE-START");

            _isWorking = true;
            _animator.SetBool("IsAnimating", true);

            yield return new WaitForSecondsRealtime(product._complexity / GetSpeedAcordingByLevel());

            _animator.SetBool("IsAnimating", false);
            _isWorking = false;

            Debug.Log("PRODUCE-FINISH");
        }
    }

    private float GetSpeedAcordingByLevel()
    {
        const float SpeedForFirstLevel = 10;

        return _level * SpeedForFirstLevel;
    }
}
