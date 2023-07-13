using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : CharacterEntity
{
    private IGraphicsComponent _graphicsComponent;
    public IGraphicsComponent GraphicsComponent { get => _graphicsComponent; }
    [SerializeField] private bool _canAttack = true;

    protected override void Awake()
    {
        base.Awake();
        _graphicsComponent = GetComponent<IGraphicsComponent>();
        HealthComponent.OnDeath += _graphicsComponent.StartDeathAnimation;
    }
    protected override void Update()
    {
        MovementComponent?.Move();
        if (IsPlayerClose() && _canAttack)
        {
            _graphicsComponent.Animator.SetTrigger("Attack");
            WeaponComponent.Weapon.Attack();
            _canAttack = false;
        }
    }
    private bool IsPlayerClose()
    {
        Vector3 enemyToPlayer = Player.PlayerCurrentPos.position - transform.position;
        if (enemyToPlayer.sqrMagnitude < 1)
        {
            return true;
        }
        return false;
    }
    public void AttackPlayer()
    {
        StartCoroutine(AttackCD());
    }
    private IEnumerator AttackCD()
    {
        _canAttack = false;
        yield return new WaitForSeconds(1 / WeaponComponent.Weapon.StatsComponent.AttackPerSecond);
        _canAttack = true;
    }
}
