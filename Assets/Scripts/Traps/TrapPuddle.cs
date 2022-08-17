using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPuddle : MonoBehaviour
{
    [SerializeField]
    private float _damage;


    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<HealthControl>().TakeDamage(_damage);
    }
}
