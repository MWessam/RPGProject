using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponStatsComponent : MonoBehaviour, IMeleeWeaponStats
{
    [SerializeField] float _attackPerSecond;
    [SerializeField] float _damage;

    public float AttackPerSecond { get => _attackPerSecond; set => _attackPerSecond = value; }
    public float Damage { get => _damage; set => _damage = value; }

    public event OnDataChange OnAttackPerSecondChange;
    public event OnDataChange OnDamageChange;

    public void UpdateStats()
    {
        throw new System.NotImplementedException();
    }
}
