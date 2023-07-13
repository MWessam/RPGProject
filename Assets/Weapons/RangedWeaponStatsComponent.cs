using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RangedWeaponStatsComponent : MonoBehaviour, IRangedWeaponStats
{

    public delegate void EventHandler();
    [SerializeField] float _damage;
    [SerializeField] float _attackPerSecond;
    [SerializeField] float _spreadAngle;
    [SerializeField] int _amountPerShot;
    public event OnDataChange OnAttackPerSecondChange;
    public event OnDataChange OnDamageChange;
    public event OnDataChange OnSpreadAngleChange;
    public event OnDataChange OnAmountPerShotChange;
    public float Damage { get => _damage; set => _damage = value; }
    public float AttackPerSecond { get => _attackPerSecond; set => _attackPerSecond = value; }
    public float SpreadAngle { get => _spreadAngle; set => _spreadAngle = value; }
    public int AmountPerShot { get => _amountPerShot; set => _amountPerShot = value; }
    private void OnEnable()
    {
        OnAttackPerSecondChange += FireRateIntermediateValueHandler;
    }

    private void OnDisable()
    {
        OnAttackPerSecondChange -= FireRateIntermediateValueHandler;
    }
    private void FireRateIntermediateValueHandler()
    {
        StaticIntermediateDataContainer<float>.IntermediateData = AttackPerSecond;
    }

    public void UpdateStats()
    {
        OnAttackPerSecondChange?.Invoke();
    }
}
