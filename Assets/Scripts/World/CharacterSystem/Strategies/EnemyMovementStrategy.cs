using UnityEngine;

public class EnemyMovementStrategy : IMovementStrategy
{
    private Transform _transform;
    private float _detectionRadius;
    private Vector2 _patrolDirection = Vector2.left;
    private float _collisionCheckDistance = 0.6f;
    
    private RaycastHit2D[] _hits = new RaycastHit2D[10];
    private ContactFilter2D _filter = new ContactFilter2D();

    public EnemyMovementStrategy(Transform transform, float chaseSpeed, float detectionRadius)
    {
        _transform = transform;
        _detectionRadius = detectionRadius;
    }

    public void Move(Rigidbody2D rigidbody2D, float speed)
    {
        CheckAndFlipDirection();

        RaycastHit2D playerHit = Physics2D.CircleCast(_transform.position, _detectionRadius, _patrolDirection, 0, GlobalSettings.PlayerMask);
        if (playerHit.collider != null)
        {
            float direction = Mathf.Sign(playerHit.collider.transform.position.x - _transform.position.x);
            
            rigidbody2D.velocity = new Vector2(direction * speed, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(_patrolDirection.x * speed, rigidbody2D.velocity.y);
        }
    }


    private void CheckAndFlipDirection()
    {
        _filter.SetLayerMask(GlobalSettings.GroundMask | GlobalSettings.EnemyMask);
        _filter.useTriggers = false;
        _filter.useLayerMask = true;
        
        _filter.useLayerMask = true;
        _filter.SetLayerMask(~GlobalSettings.EnemyMask);

        Vector2 rayStart = _transform.position;
        float rayLength = _collisionCheckDistance;

        int hitCount = Physics2D.Raycast(rayStart, _patrolDirection, _filter, _hits, rayLength);
        for (int i = 0; i < hitCount; i++)
        {
            if (_hits[i].collider != null && _hits[i].transform != _transform)
            {
                _patrolDirection *= -1;
                break;
            }
        }
    }

    public void Jump(Rigidbody2D rigidbody2D, float jumpForce)
    {
        
    }
}
