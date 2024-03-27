using UnityEngine;

public class EntityStats
{
    public int Coins;

    public int Vitality { get; private set; }
    public int Strength;
    public int Dexterity;
    
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public int Velocity { get; private set; }

    public int MaxHealth { get; private set; }
    public int MaxDamage { get; private set; }
    public int MaxVelocity { get; private set; }
    
    private readonly int _baseHealth;
    private readonly int _baseDamage;
    private readonly int _baseVelocity;
    
    public int Level => Vitality + Strength + Dexterity;

    public EntityStats()
    {
        _baseHealth = 30;
        _baseDamage = 5;
        _baseVelocity = 1;

        UpdateStats();
    }
    
    public EntityStats(int baseHealth, int baseDamage, int baseVelocity)
    {
        _baseHealth = baseHealth;
        _baseDamage = baseDamage;
        _baseVelocity = baseVelocity;
        
        UpdateStats();
    }
    
    public void SetMainStats(int vitality, int strength, int dexterity)
    {
        Vitality = vitality;
        Strength = strength;
        Dexterity = dexterity;
        UpdateStats();
    }

    private void UpdateStats()
    {
        MaxHealth = (int)Mathf.Ceil(_baseHealth + _baseHealth * 0.02f * Vitality);
        MaxDamage = (int)Mathf.Ceil(_baseDamage + _baseDamage * 0.02f * Strength);
        MaxVelocity = (int)Mathf.Ceil(_baseVelocity + _baseVelocity * 0.02f * Dexterity);

        Health = MaxHealth;
        Damage = MaxDamage;
        Velocity = MaxVelocity;
    }

    public void ModifyVitality(int value)
    {
        Vitality += value;
        UpdateStats();
    }

    public void ModifyStrength(int value)
    {
        Strength += value;
        UpdateStats();
    }

    public void ModifyDexterity(int value)
    {
        Dexterity += value;
        UpdateStats();
    }
    
    public void ModifyDamage(int value)
    {
        Damage += value;
    }
    
    public void ModifyVelocity(int value)
    {
        Velocity += value;
    } 

    public void AddHealth(int value)
    {
        Health += value;
        
        if (Health > MaxHealth)
            Health = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0) Health = 0;
    }
}