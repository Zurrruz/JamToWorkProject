using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Text _health;

    void Start()
    {
        HealthControl._damageReceived += DisplayingHealth;
    }
    private void OnDestroy()
    {
        HealthControl._damageReceived -= DisplayingHealth;
    }

    private void DisplayingHealth(float health)
    {
        if (health < 0)
            health = 0;
        _health.text = health.ToString();
    }
}
