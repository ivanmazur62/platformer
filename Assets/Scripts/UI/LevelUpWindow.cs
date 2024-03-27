using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindow : MonoBehaviour, IPanel
{
    [SerializeField] private ValueField level;
    [SerializeField] private ValueField coins;
    [SerializeField] private ValueField reqCoins;
    
    [SerializeField] private ValueField health;
    [SerializeField] private ValueField damage;
    [SerializeField] private ValueField velocity;
    
    [SerializeField] private StatField vitality;
    [SerializeField] private StatField strength;
    [SerializeField] private StatField dexterity;
    
    [SerializeField] private Button upgradeBtn;

    private EntityStats _playerStats;
    private bool _availableLevelUp;
    private int _currentCost;
    private int _previousCost;

    private void Awake()
    {
        upgradeBtn.onClick.AddListener(UpgradeStats);
        vitality.OnLevelChange += VitalityOnLevelChange;
        strength.OnLevelChange += StrengthOnLevelChange;
        dexterity.OnLevelChange += DexterityOnLevelChange;
    }

    private void OnDestroy()
    {
        upgradeBtn.onClick.RemoveListener(UpgradeStats);
        vitality.OnLevelChange -= VitalityOnLevelChange;
        strength.OnLevelChange -= StrengthOnLevelChange;
        dexterity.OnLevelChange -= DexterityOnLevelChange;
    }

    private void CheckAvailableUpdate()
    {
        CalculateUpgradeCost();
        
        _availableLevelUp = _playerStats.Coins >= _currentCost;
    }

    private void VitalityOnLevelChange(int value)
    {
        _playerStats.ModifyVitality(value);
        OnLevelChange(value);
    }
    private void StrengthOnLevelChange(int value)
    {
        _playerStats.ModifyStrength(value);
        OnLevelChange(value);
    }
    private void DexterityOnLevelChange(int value)
    {
        _playerStats.ModifyDexterity(value);
        OnLevelChange(value);
    }

    private void OnLevelChange(int value)
    {
        if(value > 0)
            _playerStats.Coins -= _currentCost;
        else
            _playerStats.Coins += _previousCost;
        
        CheckAvailableUpdate();
        UpdateStats();
    }

    private void UpgradeStats()
    {
        GameController.Instance.View.Model.PlayerStats = _playerStats;
        GameController.Instance.SavePlayerStats();
        SetupStats();
    }

    public void Show()
    {
        LoadStats();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void CalculateUpgradeCost()
    {
        int baseCost = 84;
        float costMultiplier = 0.2f;
        
        _currentCost = Mathf.CeilToInt(baseCost * Mathf.Pow(1 + costMultiplier, _playerStats.Level + 1));
        _previousCost = Mathf.CeilToInt(baseCost * Mathf.Pow(1 + costMultiplier, _playerStats.Level));
    }


    private void LoadStats()
    {
        _playerStats = GameController.Instance.View.Model.PlayerStats;

        SetupStats();
    }

    private void SetupStats()
    {
        CheckAvailableUpdate();
        
        level.SetValue(_playerStats.Level);
        coins.SetValue(_playerStats.Coins);
        reqCoins.SetValue(_currentCost);
        
        health.SetValue(_playerStats.Health);
        damage.SetValue(_playerStats.Damage);
        velocity.SetValue(_playerStats.Velocity);
        
        vitality.SetStatLevel(_playerStats.Vitality, _availableLevelUp);
        strength.SetStatLevel(_playerStats.Strength, _availableLevelUp);
        dexterity.SetStatLevel(_playerStats.Dexterity, _availableLevelUp);
    }
    
    private void UpdateStats()
    {
        level.UpdateLevel(_playerStats.Level);
        coins.UpdateLevel(_playerStats.Coins);
        reqCoins.SetValue(_currentCost);
        
        health.UpdateLevel(_playerStats.Health);
        damage.UpdateLevel(_playerStats.Damage);
        velocity.UpdateLevel(_playerStats.Velocity);
        
        vitality.UpdateStatLevel(_playerStats.Vitality, _availableLevelUp);
        strength.UpdateStatLevel(_playerStats.Strength, _availableLevelUp);
        dexterity.UpdateStatLevel(_playerStats.Dexterity, _availableLevelUp);
    }
}
