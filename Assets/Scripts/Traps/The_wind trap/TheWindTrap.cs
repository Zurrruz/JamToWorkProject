using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWindTrap : MonoBehaviour
{
    [SerializeField]
    private float _distabce;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _delay;

    private bool _isActive = true;
    private bool _theTrapIsActivated;

    void Update()
    {
        if (_theTrapIsActivated)
            ActivateTrap();
    }

    private void ActivateTrap()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, -transform.forward, out hit, _distabce))
        {
            
            if(hit.transform.tag == "Player")
            {
                hit.transform.gameObject.GetComponentInChildren<ParticleSystem>().Stop();
            }
        }
    }

    public void StartTrap()
    {
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        if (_isActive)
        {
            _isActive = false;
            yield return new WaitForSeconds(_delay);
            _theTrapIsActivated = true;
            yield return new WaitForSeconds(_cooldown);
            _theTrapIsActivated = false;
            _isActive = true;
        }
    }
}
