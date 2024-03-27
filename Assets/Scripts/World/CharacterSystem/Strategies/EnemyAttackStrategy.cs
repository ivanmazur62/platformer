using UnityEngine;

public class EnemyAttackStrategy : IAttackStrategy
{
    private float _lastAttackTime = 0f;
    private readonly float attackCooldown = 1f;
    private Transform _enemyTransform;
    private float _attackRange = 0.7f;

    public EnemyAttackStrategy(Transform transform)
    {
        _enemyTransform = transform;
    }

    public void Attack(int damage)
    {
        if (Time.time - _lastAttackTime >= attackCooldown)
        {
            Collider2D player = Physics2D.OverlapCircle(_enemyTransform.position, _attackRange, GlobalSettings.PlayerMask);
            if (player != null)
            {
                player.GetComponent<EntityBase>().TakeDamage(damage);
                _lastAttackTime = Time.time;
            }
        }
    }
}