using System;
using UnityEngine;
using UnityEngine.UI;

public class StatField : ValueField
{
    [SerializeField] private Button levelDown;
    [SerializeField] private Button levelUp;

    private bool _levelUpAvailable;

    public event Action<int> OnLevelChange;

    private void Awake()
    {
        levelDown.onClick.AddListener(OnLevelDownPressed);
        levelUp.onClick.AddListener(OnLevelUpPressed);
    }

    private void OnDestroy()
    {
        levelDown.onClick.RemoveListener(OnLevelDownPressed);
        levelUp.onClick.RemoveListener(OnLevelUpPressed);
    }

    public void SetStatLevel(int initialLevel, bool levelUpAvailable)
    {
        _levelUpAvailable = levelUpAvailable;
        base.SetValue(initialLevel);
    }
    public void UpdateStatLevel(int initialLevel, bool levelUpAvailable)
    {
        _levelUpAvailable = levelUpAvailable;
        base.UpdateLevel(initialLevel);
    }

    private void OnLevelUpPressed()
    {
        if (_levelUpAvailable && TempLevel >= CurrentLevel)
        {
            TempLevel++;
            UpdateUI();
            OnLevelChange?.Invoke(1);
        }
    }

    private void OnLevelDownPressed()
    {
        if (TempLevel > CurrentLevel)
        {
            TempLevel--;
            UpdateUI();
            OnLevelChange?.Invoke(-1);
        }
    }

    protected override void UpdateUI()
    {
        base.UpdateUI();

        levelDown.interactable = TempLevel > CurrentLevel;
        levelUp.interactable = _levelUpAvailable && TempLevel >= CurrentLevel;
    }
}