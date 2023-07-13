using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class RangedWeaponGraphicsComponent : MonoBehaviour, IWeaponGraphics
{
    [SerializeField] Animator _animator;
    [SerializeField] AnimatorOverrideController _controller;
    [SerializeField] Sprite _weaponSpriteSheetReference;
    [SerializeField] Image _weaponSprite;

    public Sprite WeaponSpriteSheetReference { get => _weaponSpriteSheetReference; }
    public Image WeaponSprite { get => _weaponSprite; }

    private void OnEnable()
    {
        _animator.runtimeAnimatorController = _controller;
        _weaponSprite.sprite = _weaponSpriteSheetReference;
    }
    public void AttackAnimation()
    {
        _animator.SetTrigger("CanShoot");
    }
    public void UpdateAnimationSpeed()
    {
        UpdateAnimationSpeedWithFloat(StaticIntermediateDataContainer<float>.IntermediateData);            // Consider it as the rax register, where i will need to store the value of the speed in this intermediate container 
                                                                                                    // since I wouldnt be able to get the required value from the other class directly, and since i want my unity event to only have void methods.
    }

    private void UpdateAnimationSpeedWithFloat(float speed)
    {
        _animator.SetFloat("Firerate", speed);
    }
}
