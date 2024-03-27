using UnityEngine;

public class PlayerAttackStrategy : IAttackStrategy
{
    private Transform _playerTransform;
    private float _attackRange = 1f;
    private float _lastAttackTime;
    private float _attackCooldown = 1f;

    private Player _player;

    public PlayerAttackStrategy(Player player, Transform playerTransform)
    {
        _player = player;
        _playerTransform = playerTransform;
    }

    public void Attack(int damage)
    {
        if (Time.time - _lastAttackTime < _attackCooldown) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(_playerTransform.position, _attackRange, GlobalSettings.EnemyMask);
            foreach (var enemy in enemies)
            {
                EntityBase enemyEntity = enemy.GetComponent<EntityBase>();
                if (enemyEntity != null)
                {
                    if (enemyEntity.TakeDamage(damage) <= 0)
                    {
                        _player.AddCoins(enemyEntity.GetCoins());
                    }
                }
            }
            _lastAttackTime = Time.time;
        }
    }
}