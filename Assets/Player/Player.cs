using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterEntity
{
    private static Transform _playerCurrentPos;
    public static Transform PlayerCurrentPos { get => _playerCurrentPos; set => _playerCurrentPos = value; }
    private PlayerLookComponent PlayerLookComponent { get => (PlayerLookComponent)LookComponent; }
    private GameObject _interactableObject;
    protected override void Awake()
    {
        base.Awake();
        if (PlayerCurrentPos == null)
            _playerCurrentPos = transform;
    }
    protected override void Update()
    {
        ShootWeapon();
    }
    private void Interactables()
    {
        PlayerLookComponent.CheckForInteractables(out _interactableObject);
    }
    private void LateUpdate()
    {
        PlayerLookComponent.Rotate(MouseMovement());
    }

    private Vector3 MouseMovement()
    {
        float inputx = Input.GetAxis("Mouse X");
        float inputy = Input.GetAxis("Mouse Y");
        return new Vector3(inputx, inputy, 90);
    }
    private void ShootWeapon()
    {
        WeaponComponent.Weapon.Attack();
    }
}
