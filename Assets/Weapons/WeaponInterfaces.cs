using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public interface IWeaponGraphics
{
    Image WeaponSprite { get; }
    Sprite WeaponSpriteSheetReference { get; }
    void AttackAnimation();
    void UpdateAnimationSpeed();
}
public delegate void OnDataChange();
public interface IWeaponStats
{
    float AttackPerSecond { get; set; }
    float Damage { get; set; }
    event OnDataChange OnDamageChange;
    event OnDataChange OnAttackPerSecondChange;
    void UpdateStats();
}
public interface IMeleeWeaponStats : IWeaponStats
{
}
public interface IRangedWeaponStats : IWeaponStats
{
    int AmountPerShot { get; set; }
    float SpreadAngle { get; set; }
    event OnDataChange OnAmountPerShotChange;
    event OnDataChange OnSpreadAngleChange;
}
public interface IAmmoComponent
{
    int MaxMagazineSize { get; set; }
    int CurrentMagazine { get; set; }
    int MaxAmmoReserve { get; set; }
    int CurrentAmmoReserve { get; set; }
    void Reload();
    void AddAmmo(int ammo);
    void ShotBullet();
}
public interface IThrowableStats : IWeaponStats
{

}
public interface IWeapon
{
    IWeaponStats StatsComponent { get; }
    IWeaponGraphics WeaponGraphics { get; }
    void Attack();
}
public interface IRangedWeapon : IWeapon
{
    IAmmoComponent AmmoComponent { get; }
    void Reload();
}

public interface IThrowable
{
    void Throw();
}
