using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    [SerializeField]
    private float _baseHealth;
    private float _currentHealth;

    public delegate void DamageReceived(float currentHealth);
    public static event DamageReceived _damageReceived;

    void Start()
    {
        _currentHealth = _baseHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _damageReceived(_currentHealth);
    }
}
