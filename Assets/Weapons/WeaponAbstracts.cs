using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : Item, IWeapon
{

    protected event Action OnAttack;
    protected bool canAttack = true;
    public IWeaponGraphics WeaponGraphics { get; protected set; }
    public abstract IWeaponStats StatsComponent { get; protected set;}

    protected virtual void Start()
    {
        StatsComponent = GetComponent<IWeaponStats>();
        WeaponGraphics = GetComponent<IWeaponGraphics>();
        OnAttack += AttackImplementation;
        if (WeaponGraphics != null)
        {
            OnAttack += WeaponGraphics.AttackAnimation;
        }
    }
    public virtual void Attack()
    {
        OnAttack?.Invoke();
    }
    protected abstract void AttackImplementation();

}
public abstract class PlayerWeapon : Weapon
{
    protected override void Start()
    {
        base.Start();
        OnAttack += AttackCDCoroutineWrapper;
    }
    public override void Attack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            base.Attack();
        }
    }
    protected abstract IEnumerator AttackCDCoroutine();
    private void AttackCDCoroutineWrapper()
    {
        StartCoroutine(AttackCDCoroutine());
    }
}
public abstract class RangedWeapon : PlayerWeapon, IRangedWeapon
{
    private IRangedWeaponStats _rangedWeaponStats;
    private IAmmoComponent _ammoComponent;
    public override IWeaponStats StatsComponent { get => _rangedWeaponStats; protected set => _rangedWeaponStats = (IRangedWeaponStats)value; }
    public IAmmoComponent AmmoComponent { get => _ammoComponent; }

    protected override void Start()
    {
        base.Start();
        _rangedWeaponStats = GetComponent<IRangedWeaponStats>();
        _ammoComponent = GetComponent<IAmmoComponent>();
        _rangedWeaponStats.OnAttackPerSecondChange += WeaponGraphics.UpdateAnimationSpeed;
        OnAttack += AmmoComponent.ShotBullet;
        _rangedWeaponStats.UpdateStats();
    }
    protected virtual void OnDisable()
    {

        _rangedWeaponStats.OnAttackPerSecondChange -= WeaponGraphics.UpdateAnimationSpeed;
    }

    public virtual void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && AmmoComponent.MaxMagazineSize != AmmoComponent.CurrentMagazine && AmmoComponent.CurrentAmmoReserve != 0)
        {
            AmmoComponent.Reload();
        }
    }
    protected override void AttackImplementation()
    {
        RaycastHit hit;
        for (int i = 0; i < _rangedWeaponStats.AmountPerShot; i++)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
            {
                hit.collider.gameObject.GetComponent<IEntity>()?.HealthComponent?.Damage(_rangedWeaponStats.Damage);
            }
        }

    }
    protected override IEnumerator AttackCDCoroutine()
    {
        canAttack = false;
        yield return new WaitForSeconds(1 / _rangedWeaponStats.AttackPerSecond);        // Calculate cooldown between shots/attacks
        canAttack = true;
    }
    public void PickUpSameWeapon()
    {
        AmmoComponent.AddAmmo(AmmoComponent.MaxAmmoReserve / 2);
    }
}
