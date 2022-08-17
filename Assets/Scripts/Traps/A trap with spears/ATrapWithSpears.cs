using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATrapWithSpears : MonoBehaviour
{
    [SerializeField]
    private GameObject _spears;
    [SerializeField]
    private Transform _upSpot;
    [SerializeField]
    private Transform _downSpot;
    private Transform _actualSpot;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _delay;
    [SerializeField]
    private float _cooldown;
    private bool _theTrapIsActivated;
    bool _isActive = true;

    private void Update()
    {
        if (_theTrapIsActivated)
            MoveSpears();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActive)
        {
            StartCoroutine(Activate());
            _actualSpot = _upSpot;
        }
    }

    private void MoveSpears()
    {
        _spears.transform.position = Vector3.MoveTowards(_spears.transform.position, _actualSpot.position, _speed * Time.deltaTime);
    }

    IEnumerator Activate()
    {
        _isActive = false;
        yield return new WaitForSeconds(_delay);
        _theTrapIsActivated = true;
        yield return new WaitForSeconds(_cooldown);
        _actualSpot = _downSpot;

        _isActive = true;
    }
}
