using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBase
{
    private Dictionary<string, Coroutine> _activeEffects = new Dictionary<string, Coroutine>();
    private Dictionary<string, int> _effectAmounts = new Dictionary<string, int>();

    public event Action<EntityStats> OnUpdateStats;
    public event Action<string, float> OnPowerUpStarted; 
    public event Action<string> OnPowerUpEnded;
    
    protected override void Awake()
    {
        base.Awake();
        
        SetMovementStrategy(new PlayerMovementStrategy());
        SetAttackStrategy(new PlayerAttackStrategy(this, transform));
    }

    public new void Initialize(EntityStats entityStats)
    {
        base.Initialize(entityStats);
    }
    
    protected override void LocalUpdate()
    {
        Move();
        IsGrounded = CheckGrounding();
        if(!IsGrounded) return;
        
        Jump();
        Attack();
    }

    protected override void Jump()
    {
        if (IsGrounded && Input.GetButtonDown("Jump"))
            base.Jump();
    }

    public override int TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        OnUpdateStats?.Invoke(Stats);

        return Stats.Health;
    }

    protected override bool CheckGrounding()
    {
        var hit = Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, GlobalSettings.GroundMask | GlobalSettings.EnemyMask);
        return hit.collider != null;
    }

    public void ModifyDamage(int extraDamage)
    {
        Stats.ModifyDamage(extraDamage);
        OnUpdateStats?.Invoke(Stats);
    }

    public void ModifyVelocity(int extraVelocity)
    {
        Stats.ModifyVelocity(extraVelocity);
        OnUpdateStats?.Invoke(Stats);
    }

    public void ModifyHealth(int extraHealth)
    {
        Stats.AddHealth(extraHealth);
        OnUpdateStats?.Invoke(Stats);
    }

    public void AddCoins(int coinValue)
    {
        Stats.Coins += coinValue;
        OnUpdateStats?.Invoke(Stats);
    }
    
    public void ApplyEffect(string effectType, int amount, float duration)
    {
        if (!_activeEffects.ContainsKey(effectType))
        {
            switch (effectType)
            {
                 case "Strength":
                     ModifyDamage(amount);
                     break;
                 case "Dexterity":
                     ModifyVelocity(amount);
                     break;
            }

            _effectAmounts[effectType] = amount;
            StartEffectCoroutine(effectType, ResetEffect(effectType, duration));
        }
        else
        {
            UpdateEffectCoroutine(effectType, duration);
        }
    }

    private void StartEffectCoroutine(string effectType, IEnumerator coroutine)
    {
        StopEffect(effectType);
        _activeEffects[effectType] = StartCoroutine(coroutine);
    }

    private void UpdateEffectCoroutine(string effectType, float duration)
    {
        StartEffectCoroutine(effectType, ResetEffect(effectType, duration));
    }

    private void StopEffect(string effectType)
    {
        if (_activeEffects.ContainsKey(effectType))
        {
            StopCoroutine(_activeEffects[effectType]);
            _activeEffects.Remove(effectType);
        }
    }

    private IEnumerator ResetEffect(string effectType, float duration)
    {
        OnPowerUpStarted?.Invoke(effectType, duration);
        
        yield return new WaitForSeconds(duration);
        
        if (effectType == "Dexterity")
        {
            ModifyVelocity(-_effectAmounts[effectType]);
        }
        else if (effectType == "Strength")
        {
            ModifyDamage(-_effectAmounts[effectType]);
        }
        
        _effectAmounts.Remove(effectType);
        _activeEffects.Remove(effectType);
        OnPowerUpEnded?.Invoke(effectType);
    }
}