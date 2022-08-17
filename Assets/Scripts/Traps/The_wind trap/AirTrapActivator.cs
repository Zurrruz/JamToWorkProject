using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTrapActivator : MonoBehaviour
{
    [SerializeField]
    private TheWindTrap _theWindTrap;

    private void OnTriggerEnter(Collider other)
    {
        _theWindTrap.StartTrap();
    }

}
