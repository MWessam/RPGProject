using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGraphicsComponent : MonoBehaviour, IGraphicsComponent
{
    [SerializeField] AnimatorOverrideController _animatorOverrideController;
    private Animator _animator;
    public AnimatorOverrideController AnimatorController => _animatorOverrideController;

    public Animator Animator { get => _animator; }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.runtimeAnimatorController = _animatorOverrideController;
    }
    public void StartDeathAnimation()
    {
        _animator.SetBool("IsDead", true);
    }
}
