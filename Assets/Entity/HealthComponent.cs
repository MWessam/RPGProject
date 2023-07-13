using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IHealthComponent
{
    public event Action OnHealthChange;
    public event Action OnDeath;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    public float Health
    {
        get => _health;
        set
        {
            if (value > _maxHealth)
            {
                _health = _maxHealth;
            }
            else if (value <= 0)
            {
                _health = 0;
                OnDeath?.Invoke();
            }
            else
            {
                _health = value;
            }
        }
    }
    private void Start()
    {
        _health = _maxHealth;
        OnDeath += Die;
    }

    public void Damage(float damage)
    {
        Health -= damage;
    }
    public void Heal(float health)
    {
        Health += health;
    }
    private void Die()
    {
        Destroy(gameObject, 1f);
        OnDeath -= Die;
    }
}
