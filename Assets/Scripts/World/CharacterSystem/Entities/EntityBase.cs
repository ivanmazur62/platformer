using System;
using UnityEngine;

public abstract class EntityBase : WorldObject
{
    public EntityStats Stats { get; protected set; }

    protected readonly float JumpForce = 7f;
    protected Rigidbody2D Rigidbody2D;

    protected IMovementStrategy MovementStrategy;
    protected IAttackStrategy AttackStrategy;

    public event Action<EntityBase> OnDeath;

    protected Transform GroundCheck;
    protected readonly float GroundCheckDistance = 0.6f;
    protected bool IsGrounded;

    protected virtual void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        GroundCheck = transform;
    }

    public virtual void Initialize(int vitality, int strength, int dexterity)
    {
        Stats = new EntityStats();
        Stats.SetMainStats(vitality, strength, dexterity);

        gameObject.SetActive(true);
    }
    public void Initialize(int baseHealth, int baseDamage, int baseSpeed, int vitality, int strength, int dexterity)
    {
        Stats = new EntityStats(baseHealth, baseDamage, baseSpeed);
        Stats.SetMainStats(vitality, strength, dexterity);

        gameObject.SetActive(true);
        gameObject.transform.position = Vector3.zero;
    }
    
    public void Initialize(EntityStats entityStats)
    {
        Stats = entityStats;

        gameObject.SetActive(true);
        gameObject.transform.position = Vector3.zero;
    }

    protected override void LocalUpdate()
    {
        IsGrounded = CheckGrounding();
        
        if(!IsGrounded) return;
        
        Move();
        Jump();
    }

    public int GetCoins()
    {
        Debug.Log("GetCoins = " + Stats.Coins);
        return Stats.Coins;
    }
    
    protected virtual bool CheckGrounding()
    {
        var hit = Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, GlobalSettings.GroundMask);
        return hit.collider != null;
    }
    
    protected void SetMovementStrategy(IMovementStrategy strategy)
    {
        MovementStrategy = strategy;
    }

    protected void SetAttackStrategy(IAttackStrategy strategy)
    {
        AttackStrategy = strategy;
    }

    public virtual int TakeDamage(int amount)
    {
        Stats.TakeDamage(amount);

        if (Stats.Health <= 0) Die();
        
        return Stats.Health;
    }

    public virtual void Die()
    {
        Debug.Log(GetType() + " Die");
        OnDeath?.Invoke(this);
    }

    protected void Move()
    {
        MovementStrategy?.Move(Rigidbody2D, Stats.Velocity);
    }

    protected virtual void Jump()
    {
        MovementStrategy?.Jump(Rigidbody2D, JumpForce);
    }

    protected void Attack()
    {
        AttackStrategy?.Attack(Stats.Damage);
    }
}
