using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInventoryComponent
{
    List<Item> Items { get; }
    event Action OnPickup;
    event Action OnDrop;
}
public interface IHealthComponent
{
    event Action OnHealthChange;
    event Action OnDeath;
    float Health { get; set; }
    //float DamageEndurance { get; set; }
    void Heal(float health);
    void Damage(float damage);
}
public interface ILevelComponent
{
    event Action OnXPGain;
    event Action OnLevelUp;
    float Level { get; set; }
    float CurrentXP { get; set; }
    float XPToLevelUp { get; set; }
    void LevelUp();
    void GainXP();
}
public interface IMovementComponent
{
    float Speed { get; set; }
    void Move();
}
public interface ILookComponent
{
    Transform ParentTransform { get; }
    void Look(Transform target);
}
public interface IGraphicsComponent
{
    AnimatorOverrideController AnimatorController { get; }
    Animator Animator { get; }
    void StartDeathAnimation();
}
public interface IWeaponComponent
{
    IWeapon Weapon { get; }
}

public interface IEntity
{
    IHealthComponent HealthComponent { get; }

}
public interface ICharacterEntity
{
    ILookComponent LookComponent { get; }
    IMovementComponent MovementComponent { get; }
    IWeaponComponent WeaponComponent { get; }
}