using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class Entity : MonoBehaviour, IEntity
{
    private IHealthComponent _healthComponent;
    public IHealthComponent HealthComponent { get => _healthComponent; }
    protected virtual void Awake()
    {
        _healthComponent = GetComponent<IHealthComponent>();
    }


}
public abstract class CharacterEntity : Entity, ICharacterEntity
{
    private ILookComponent _lookComponent;
    private IMovementComponent _movementComponent;
    private IWeaponComponent _weaponComponent;
    public ILookComponent LookComponent { get => _lookComponent; }
    public IMovementComponent MovementComponent { get => _movementComponent; }
    public IWeaponComponent WeaponComponent { get => _weaponComponent; }


    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _movementComponent = GetComponent<IMovementComponent>();
        _lookComponent = GetComponent<ILookComponent>();
        _weaponComponent = GetComponent<IWeaponComponent>();
    }

    // Update is called once per frame
    protected abstract void Update();
}
