using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerLookComponent : LookComponent
{
    public static UnityEvent onMouseInput = new();
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _mainObjectTransform;
    float _verticalRotation = 0f;
    float _horizontalRotation = 0f;
    [SerializeField] private float _smooth;
    [SerializeField] private float _swayDistance;
    [SerializeField] private Image _weaponSprite;
    Vector3 _originalWeaponPos;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _originalWeaponPos = _weaponSprite.rectTransform.position;
    }
    public void CheckForInteractables(out GameObject interactable)
    {
        RaycastHit hit;
        if (Physics.Raycast(_mainObjectTransform.position, _mainObjectTransform.forward, out hit, 2.0f, LayerMask.NameToLayer("Interactables")))
        {
            interactable = hit.collider.gameObject;
            return;
        }
        interactable = null;
    }
    public override Transform ParentTransform { get => _mainObjectTransform; }
    public void Rotate(Vector3 rotation)
    {
        rotation *= _rotationSpeed;
        _horizontalRotation += rotation.x;
        _verticalRotation -= rotation.y;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -75f, 75f);
        _mainObjectTransform.localEulerAngles = new Vector3(_verticalRotation, _horizontalRotation);
        //Sway(ref rotation);
    }
    private void Sway(ref Vector3 mouseInput)
    {
        if (mouseInput.sqrMagnitude == 0)
        {
            _weaponSprite.rectTransform.position = Vector3.Lerp(_weaponSprite.rectTransform.position, _originalWeaponPos, _smooth * Time.deltaTime);
        }
        else
        {
            _weaponSprite.rectTransform.position += new Vector3(Mathf.Clamp(mouseInput.x * _rotationSpeed * _swayDistance, -_swayDistance, _swayDistance), 0, 0);
        }
    }
}
